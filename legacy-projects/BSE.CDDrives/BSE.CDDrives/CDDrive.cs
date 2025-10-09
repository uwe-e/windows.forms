//
//
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER 
//  REMAINS UNCHANGED.
//
//  Email:  yetiicb@hotmail.com
//
//  Copyright (C) 2002-2003 Idael Cardoso. 
//

using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Globalization;
using System.Diagnostics.CodeAnalysis;
using System.Security.Permissions;

namespace BSE.CDDrives
{
    //public class CDBufferFiller
    //{
    //    byte[] BufferArray;
    //    int WritePosition;

    //    public CDBufferFiller(byte[] aBuffer)
    //    {
    //        BufferArray = aBuffer;
    //    }
    //    public void OnCDDataRead(object sender, DataReadEventArgs ea)
    //    {
    //        Buffer.BlockCopy(ea.Data, 0, BufferArray, WritePosition, (int)ea.DataSize);
    //        WritePosition += (int)ea.DataSize;
    //    }
    //}

    /// <summary>
    /// 
    /// </summary>
    public class CDDrive : IDisposable
    {
        #region Events
        public event EventHandler CDInserted;
        public event EventHandler CDRemoved;
        #endregion

        #region Constants
        private const int NSECTORS = 13;
        private const int UNDERSAMPLING = 1;
        private const int CB_CDDASECTOR = 2368;
        private const int CB_QSUBCHANNEL = 16;
        private const int CB_CDROMSECTOR = 2048;
        private const int CB_AUDIO = (CB_CDDASECTOR - CB_QSUBCHANNEL);
        #endregion

        #region FieldsPrivate
        private IntPtr cdHandle;
        private bool TocValid;
        private NativeMethods.CDROM_TOC Toc;
        private char m_Drive;
        private DeviceChangeNotificationWindow NotWnd;
        // Track whether Dispose has been called.
        private bool m_bDisposed;

        #endregion

        #region Properties
        /// <summary>
        /// Gets the number of tracks on the CD
        /// </summary>
        /// <value>
        /// The number of tracks. If error the return value is -1.
        /// </value>
        public int NumberOfTracks
        {
            get
            {
                return this.GetNumberOfTracks();
            }
        }
        /// <summary>
        /// Gets the number of audio tracks on the CD
        /// </summary>
        /// <value>
        /// The number of audio tracks. If error the return value is -1.
        /// </value>
        public int NumberOfAudioTracks
        {
            get
            {
                return this.GetNumberOfAudioTracks();
            }
        }
        #endregion

        #region MethodsPublic
        public CDDrive()
        {
            Toc = new NativeMethods.CDROM_TOC();
            cdHandle = IntPtr.Zero;
        }
        public bool Open(char drive)
        {
            Close();
            if (NativeMethods.GetDriveType(drive + ":\\") == NativeMethods.DriveTypes.DRIVE_CDROM)
            {
                cdHandle = NativeMethods.CreateFile("\\\\.\\" + drive + ':', NativeMethods.GENERIC_READ, NativeMethods.FILE_SHARE_READ, IntPtr.Zero, NativeMethods.OPEN_EXISTING, 0, IntPtr.Zero);
                if (((int)cdHandle != -1) && ((int)cdHandle != 0))
                {
                    m_Drive = drive;
                    NotWnd = new DeviceChangeNotificationWindow();
                    NotWnd.DeviceChange += new EventHandler<DeviceChangeEventArgs>(NotWnd_DeviceChange);
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public void Close()
        {
            UnlockCD();
            if (NotWnd != null)
            {
                NotWnd.DestroyHandle();
                NotWnd = null;
            }
            if (((int)cdHandle != -1) && ((int)cdHandle != 0))
            {
                NativeMethods.CloseHandle(cdHandle);
            }
            cdHandle = IntPtr.Zero;
            m_Drive = '\0';
            TocValid = false;
        }
        public bool IsOpened
        {
            get
            {
                return ((int)cdHandle != -1) && ((int)cdHandle != 0);
            }
        }
        /// <summary>
        /// Lock the CD drive 
        /// </summary>
        /// <returns>True on success</returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool LockCD()
        {
            if (((int)cdHandle != -1) && ((int)cdHandle != 0))
            {
                uint Dummy = 0;
                NativeMethods.PREVENT_MEDIA_REMOVAL pmr = new NativeMethods.PREVENT_MEDIA_REMOVAL();
                pmr.PreventMediaRemoval = 1;
                return NativeMethods.DeviceIoControl(cdHandle, NativeMethods.IOCTL_STORAGE_MEDIA_REMOVAL, pmr, (uint)Marshal.SizeOf(pmr), IntPtr.Zero, 0, ref Dummy, IntPtr.Zero) != 0;
            }
            return false;
        }
        /// <summary>
        /// Unlock CD drive
        /// </summary>
        /// <returns>True on success</returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool UnlockCD()
        {
            if (((int)cdHandle != -1) && ((int)cdHandle != 0))
            {
                uint Dummy = 0;
                NativeMethods.PREVENT_MEDIA_REMOVAL pmr = new NativeMethods.PREVENT_MEDIA_REMOVAL();
                pmr.PreventMediaRemoval = 0;
                return NativeMethods.DeviceIoControl(cdHandle, NativeMethods.IOCTL_STORAGE_MEDIA_REMOVAL, pmr, (uint)Marshal.SizeOf(pmr), IntPtr.Zero, 0, ref Dummy, IntPtr.Zero) != 0;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Close the CD drive door
        /// </summary>
        /// <returns>True on success</returns>
        public bool LoadCD()
        {
            TocValid = false;
            if (((int)cdHandle != -1) && ((int)cdHandle != 0))
            {
                uint Dummy = 0;
                return NativeMethods.DeviceIoControl(cdHandle, NativeMethods.IOCTL_STORAGE_LOAD_MEDIA, IntPtr.Zero, 0, IntPtr.Zero, 0, ref Dummy, IntPtr.Zero) != 0;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Open the CD drive door
        /// </summary>
        /// <returns>True on success</returns>
        public bool EjectCD()
        {
            TocValid = false;
            if (((int)cdHandle != -1) && ((int)cdHandle != 0))
            {
                uint Dummy = 0;
                return NativeMethods.DeviceIoControl(cdHandle, NativeMethods.IOCTL_STORAGE_EJECT_MEDIA, IntPtr.Zero, 0, IntPtr.Zero, 0, ref Dummy, IntPtr.Zero) != 0;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Check if there is CD in the drive
        /// </summary>
        /// <returns>True on success</returns>
        public bool IsCDReady()
        {
            if (((int)cdHandle != -1) && ((int)cdHandle != 0))
            {
                uint Dummy = 0;
                if (NativeMethods.DeviceIoControl(cdHandle, NativeMethods.IOCTL_STORAGE_CHECK_VERIFY, IntPtr.Zero, 0, IntPtr.Zero, 0, ref Dummy, IntPtr.Zero) != 0)
                {
                    return true;
                }
                else
                {
                    TocValid = false;
                    return false;
                }
            }
            else
            {
                TocValid = false;
                return false;
            }
        }
        /// <summary>
        /// If there is a CD in the drive read its TOC
        /// </summary>
        /// <returns>True on success</returns>
        public bool Refresh()
        {
            if (IsCDReady())
            {
                return ReadTOC();
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Read the digital data of the track
        /// </summary>
        /// <param name="track">Track to read</param>
        /// <param name="data">Buffer that will receive the data</param>
        /// <param name="dataSize">On return the size needed to read the track</param>
        /// <param name="startSecond">First second of the track to read, 0 means to start at beginning of the track</param>
        /// <param name="seconds2Read">Number of seconds to read, 0 means to read until the end of the track</param>
        /// <param name="progressEvent">Delegate to indicate the reading progress</param>
        /// <returns>Negative value means an error. On success returns the number of bytes read</returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public int ReadTrack(int track, byte[] data, ref uint dataSize, uint startSecond, uint seconds2Read, EventHandler<ReadProgressEventArgs> progressEvent)
        {
            if (TocValid && (track >= Toc.FirstTrack) && (track <= Toc.LastTrack))
            {
                int StartSect = GetStartSector(track);
                int EndSect = GetEndSector(track);
                if ((StartSect += (int)startSecond * 75) >= EndSect)
                {
                    StartSect -= (int)startSecond * 75;
                }
                if ((seconds2Read > 0) && ((int)(StartSect + seconds2Read * 75) < EndSect))
                {
                    EndSect = StartSect + (int)seconds2Read * 75;
                }
                dataSize = (uint)(EndSect - StartSect) * CB_AUDIO;
                if (data != null)
                {
                    if (data.Length >= dataSize)
                    {
                        CDBufferFiller bufferFiller = new CDBufferFiller(data);
                        return ReadTrack(
                            track,
                            new EventHandler<DataReadEventArgs>(bufferFiller.OnCDDataRead),
                            startSecond,
                            seconds2Read,
                            progressEvent);
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// Read the digital data of the track
        /// </summary>
        /// <param name="track">Track to read</param>
        /// <param name="data">Buffer that will receive the data</param>
        /// <param name="dataSize">On return the size needed to read the track</param>
        /// <param name="progressEvent">Delegate to indicate the reading progress</param>
        /// <returns>Negative value means an error. On success returns the number of bytes read</returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public int ReadTrack(int track, byte[] data, ref uint dataSize, EventHandler<ReadProgressEventArgs> progressEvent)
        {
            return ReadTrack(track, data, ref dataSize, 0, 0, progressEvent);
        }
        /// <summary>
        /// Read the digital data of the track
        /// </summary>
        /// <param name="trackNo">Track to read</param>
        /// <param name="dataReadEvent">Call each time data is read</param>
        /// <param name="startSecond">First second of the track to read, 0 means to start at beginning of the track</param>
        /// <param name="Seconds2Read">Number of seconds to read, 0 means to read until the end of the track</param>
        /// <param name="progressEvent">Delegate to indicate the reading progress</param>
        /// <returns>Negative value means an error. On success returns the number of bytes read</returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public int ReadTrack(int trackNo, EventHandler<DataReadEventArgs> dataReadEvent, uint startSecond,
            uint seconds2Read, EventHandler<ReadProgressEventArgs> progressEvent)
        {
            if (TocValid && (trackNo >= Toc.FirstTrack) && (trackNo <= Toc.LastTrack) && (dataReadEvent != null))
            {
                int StartSect = GetStartSector(trackNo);
                int EndSect = GetEndSector(trackNo);
                if ((StartSect += (int)startSecond * 75) >= EndSect)
                {
                    StartSect -= (int)startSecond * 75;
                }
                if ((seconds2Read > 0) && ((int)(StartSect + seconds2Read * 75) < EndSect))
                {
                    EndSect = StartSect + (int)seconds2Read * 75;
                }
                uint Bytes2Read = (uint)(EndSect - StartSect) * CB_AUDIO;
                uint BytesRead = 0;
                byte[] Data = new byte[CB_AUDIO * NSECTORS];
                bool Cont = true;
                bool ReadOk = true;
                if (progressEvent != null)
                {
                    ReadProgressEventArgs rpa = new ReadProgressEventArgs(Bytes2Read, 0, 0, trackNo);
                    progressEvent(this, rpa);
                    Cont = !rpa.CancelRead;
                }
                for (int sector = StartSect; (sector < EndSect) && (Cont) && (ReadOk); sector += NSECTORS)
                {
                    int Sectors2Read = ((sector + NSECTORS) < EndSect) ? NSECTORS : (EndSect - sector);
                    ReadOk = ReadSector(sector, Data, Sectors2Read);
                    if (ReadOk)
                    {
                        DataReadEventArgs dra = new DataReadEventArgs(Data, (uint)(CB_AUDIO * Sectors2Read));
                        dataReadEvent(this, dra);
                        BytesRead += (uint)(CB_AUDIO * Sectors2Read);
                        if (progressEvent != null)
                        {
                            ReadProgressEventArgs readProgressEventArgs = new ReadProgressEventArgs(Bytes2Read, BytesRead, seconds2Read, trackNo);
                            progressEvent(this, readProgressEventArgs);
                            Cont = !readProgressEventArgs.CancelRead;
                        }
                    }
                }
                if (ReadOk)
                {
                    return (int)BytesRead;
                }
                else
                {
                    return -1;
                }

            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// Read the digital data of the track
        /// </summary>
        /// <param name="track">Track to read</param>
        /// <param name="dataReadEvent">Call each time data is read</param>
        /// <param name="progressEvent">Delegate to indicate the reading progress</param>
        /// <returns>Negative value means an error. On success returns the number of bytes read</returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public int ReadTrack(int track, EventHandler<DataReadEventArgs> dataReadEvent, EventHandler<ReadProgressEventArgs> progressEvent)
        {
            return ReadTrack(track, dataReadEvent, 0, 0, progressEvent);
        }
        /// <summary>
        /// Get track size
        /// </summary>
        /// <param name="track">Track</param>
        /// <returns>Size in bytes of track data</returns>
        public uint TrackSize(int track)
        {
            uint Size = 0;
            ReadTrack(track, null, ref Size, null);
            return Size;
        }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public string Duration(int iTrack)
        {
            TimeSpan durationTime = GetDuration(iTrack);
            return durationTime.Hours.ToString("00",CultureInfo.InvariantCulture)
                + ":" + durationTime.Minutes.ToString("00", CultureInfo.InvariantCulture)
                + ":" + durationTime.Seconds.ToString("00", CultureInfo.InvariantCulture);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool IsAudioTrack(int track)
        {
            if ((TocValid) && (track >= Toc.FirstTrack) && (track <= Toc.LastTrack))
            {
                return (Toc.TrackData[track - 1].Control & 4) == 0;
            }
            return false;
        }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public string GetDiskId()
        {
            int minutes;
            int seconds;
            int iCDDBSum = 0;

            int iNumTracks = GetNumberOfTracks();

            for (int i = 0; i < iNumTracks; i++)
            {
                minutes = Toc.TrackData[i].Address_1;
                seconds = Toc.TrackData[i].Address_2;

                if (i < iNumTracks)
                {
                    iCDDBSum = iCDDBSum + GetCDDBSum((minutes * 60) + seconds);
                }
            }

            int t = ((Toc.TrackData[iNumTracks].Address_1 * 60) + Toc.TrackData[iNumTracks].Address_2) -
                ((Toc.TrackData[0].Address_1 * 60) + Toc.TrackData[0].Address_2);

            ulong lDiskId = (((uint)iCDDBSum % 0xff) << 24 | (uint)t << 8 | (uint)iNumTracks);
            string strDiskId = String.Format(CultureInfo.InvariantCulture, "{0:x8}", lDiskId);

            return strDiskId;
        }
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public TimeSpan GetDuration(int iTrackIndex)
        {
            return GetEndTime(iTrackIndex).Subtract(GetStartTime(iTrackIndex));
        }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public string GetQueryStringOfDisc()
        {
            int minutes;
            int seconds;
            int frames;
            int offset = 0;
            int iCDDBSum = 0;

            StringBuilder stringBuilderTOC = new StringBuilder();
            int iNumTracks = GetNumberOfTracks();

            for (int i = 0; i < iNumTracks; i++)
            {
                minutes = Toc.TrackData[i].Address_1;
                seconds = Toc.TrackData[i].Address_2;
                frames = Toc.TrackData[i].Address_3;

                offset = (minutes * 60 * 75) + (seconds * 75) + frames;
                stringBuilderTOC.Append("+" + offset.ToString(CultureInfo.InvariantCulture));
                if (i < iNumTracks)
                {
                    iCDDBSum = iCDDBSum + GetCDDBSum((minutes * 60) + seconds);
                }
            }

            stringBuilderTOC.Append("+" + (Toc.TrackData[iNumTracks].Address_1 * 60 + Toc.TrackData[iNumTracks].Address_2));

            int t = ((Toc.TrackData[iNumTracks].Address_1 * 60) + Toc.TrackData[iNumTracks].Address_2) -
                ((Toc.TrackData[0].Address_1 * 60) + Toc.TrackData[0].Address_2);

            ulong lDiskId = (((uint)iCDDBSum % 0xff) << 24 | (uint)t << 8 | (uint)iNumTracks);
            string strDiskId = String.Format(CultureInfo.InvariantCulture,"{0:x8}", lDiskId);
            return strDiskId + "+" + iNumTracks + stringBuilderTOC.ToString().Trim();
        }

        public static char[] GetCDDriveLetters()
        {
            string res = "";
            for (char c = 'C'; c <= 'Z'; c++)
            {
                if (NativeMethods.GetDriveType(c + ":") == NativeMethods.DriveTypes.DRIVE_CDROM)
                {
                    res += c;
                }
            }
            return res.ToCharArray();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // Use C# destructor syntax for finalization code.
        // This destructor will run only if the Dispose method 
        // does not get called.
        // It gives your base class the opportunity to finalize.
        // Do not provide destructors in types derived from this class.
        ~CDDrive()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
        }

        #endregion

        #region MethodsProtected
        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// If disposing equals false, the method has been called by the 
        /// runtime from inside the finalizer and you should not reference 
        /// other objects. Only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (this.m_bDisposed == false)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                }
                // Release unmanaged resources. If disposing is false, 
                // only the following code is executed.
                this.Close();
            }
            this.m_bDisposed = true;
        }
        #endregion

        #region MethodsPrivate
        /// <summary>
        /// Return the number of tracks on the CD
        /// </summary>
        /// <returns>-1 on error</returns>
        private int GetNumberOfTracks()
        {
            if (TocValid)
            {
                return Toc.LastTrack - Toc.FirstTrack + 1;
            }
            else return -1;
        }
        /// <summary>
        /// Return the number of audio tracks on the CD
        /// </summary>
        /// <returns>-1 on error</returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private int GetNumberOfAudioTracks()
        {
            if (TocValid)
            {
                int iTracks = 0;
                for (int i = Toc.FirstTrack - 1; i < Toc.LastTrack; i++)
                {
                    if (Toc.TrackData[i].Control == 0)
                    {
                        iTracks++;
                    }
                }
                return iTracks;
            }
            return -1;
        }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private bool ReadTOC()
        {
            if (((int)cdHandle != -1) && ((int)cdHandle != 0))
            {
                uint BytesRead = 0;
                TocValid = NativeMethods.DeviceIoControl(cdHandle, NativeMethods.IOCTL_CDROM_READ_TOC, IntPtr.Zero, 0, Toc, (uint)Marshal.SizeOf(Toc), ref BytesRead, IntPtr.Zero) != 0;
            }
            else
            {
                TocValid = false;
            }
            return TocValid;
        }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private int GetStartSector(int track)
        {
            if (TocValid && (track >= Toc.FirstTrack) && (track <= Toc.LastTrack))
            {
                NativeMethods.TRACK_DATA td = Toc.TrackData[track - 1];
                return (td.Address_1 * 60 * 75 + td.Address_2 * 75 + td.Address_3) - 150;
            }
            else
            {
                return -1;
            }
        }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private int GetEndSector(int track)
        {
            if (TocValid && (track >= Toc.FirstTrack) && (track <= Toc.LastTrack))
            {
                NativeMethods.TRACK_DATA td = Toc.TrackData[track];
                return (td.Address_1 * 60 * 75 + td.Address_2 * 75 + td.Address_3) - 151;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// Read Audio Sectors
        /// </summary>
        /// <param name="sector">The sector where to start to read</param>
        /// <param name="buffer">The length must be at least CB_CDDASECTOR*Sectors bytes</param>
        /// <param name="numSectors">Number of sectors to read</param>
        /// <returns>True on success</returns>
        private bool ReadSector(int sector, byte[] buffer, int numSectors)
        {
            if (TocValid && ((sector + numSectors) <= GetEndSector(Toc.LastTrack)) && (buffer.Length >= CB_AUDIO * numSectors))
            {
                NativeMethods.RAW_READ_INFO rri = new NativeMethods.RAW_READ_INFO();
                rri.TrackMode = NativeMethods.TRACK_MODE_TYPE.CDDA;
                rri.SectorCount = (uint)numSectors;
                rri.DiskOffset = sector * CB_CDROMSECTOR;

                uint BytesRead = 0;
                if (NativeMethods.DeviceIoControl(cdHandle, NativeMethods.IOCTL_CDROM_RAW_READ, rri, (uint)Marshal.SizeOf(rri), buffer, (uint)numSectors * CB_AUDIO, ref BytesRead, IntPtr.Zero) != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
        private TimeSpan GetStartTime(int iTrackIndex)
        {
            TimeSpan timeSpan = new TimeSpan();
            if (TocValid && (iTrackIndex >= Toc.FirstTrack) && (iTrackIndex <= Toc.LastTrack))
            {
                NativeMethods.TRACK_DATA td = Toc.TrackData[iTrackIndex - 1];

                int iMinute = td.Address_1;
                int iSeconds = td.Address_2;
                int iHour = 0;

                if (iMinute >= 60)
                {
                    iHour = iMinute / 60;
                    iMinute = iMinute % 60;
                }
                return new TimeSpan(iHour, iMinute, iSeconds);
            }
            return timeSpan;
        }
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
        private TimeSpan GetEndTime(int iTrackIndex)
        {
            TimeSpan timeSpan = new TimeSpan();
            if (TocValid && (iTrackIndex >= Toc.FirstTrack) && (iTrackIndex <= Toc.LastTrack))
            {
                NativeMethods.TRACK_DATA td = Toc.TrackData[iTrackIndex];
                int iMinute = td.Address_1;
                int iSeconds = td.Address_2;
                int iHour = 0;

                if (iMinute >= 60)
                {
                    iHour = iMinute / 60;
                    iMinute = iMinute % 60;
                }
                return new TimeSpan(iHour, iMinute, iSeconds);
            }
            return timeSpan;
        }
        private static int GetCDDBSum(int n)
        {
            int iCDDBSum = 0;

            while (n > 0)
            {
                iCDDBSum = iCDDBSum + (n % 10);
                n = n / 10;
            }

            return iCDDBSum;

        }
        private void OnCDInserted()
        {
            if (CDInserted != null)
            {
                CDInserted(this, EventArgs.Empty);
            }
        }

        private void OnCDRemoved()
        {
            if (CDRemoved != null)
            {
                CDRemoved(this, EventArgs.Empty);
            }
        }

        private void NotWnd_DeviceChange(object sender, DeviceChangeEventArgs ea)
        {
            if (ea.Drive == m_Drive)
            {
                TocValid = false;
                switch (ea.DeviceChangeEventType)
                {
                    case DeviceChangeEventType.DeviceInserted:
                        OnCDInserted();
                        break;
                    case DeviceChangeEventType.DeviceRemoved:
                        OnCDRemoved();
                        break;
                }
            }
        }
        #endregion
    }
}
