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
using System.IO;
using BSE.Platten.Ripper.Properties;
using System.Globalization;

namespace BSE.Platten.Ripper.AudioWriters
{
    /// <summary>
    /// Writes wave format types in binary to a stream and supports writing strings in a specific encoding.
    /// </summary>
    public class WaveWriter : AudioWriter
    {
        #region Constants
        private const uint WaveHeaderSize = 38;
        private const uint WaveFormatSize = 18;
        #endregion

        #region FieldsPrivate
        private uint m_audioDataSize;
        private uint m_writtenBytes;
        private bool m_bClosed;
        private WaveFormat m_waveFormat;
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="WaveWriter"/> class based on the supplied stream using ASCII as the encoding for strings and the given configuration.
        /// </summary>
        /// <param name="output">The output stream.</param>
        /// <param name="writerConfiguration">The <see cref="WaveWriterConfiguration"/> configuration.</param>
        public WaveWriter(Stream output, WaveWriterConfiguration writerConfiguration)
            : this(output, writerConfiguration.WaveFormat)
        {
            if (writerConfiguration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "writerConfiguration"));
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="WaveWriter"/> class based on the supplied stream using ASCII as the encoding for strings and the given wave format.
        /// </summary>
        /// <param name="output">The output stream.</param>
        /// <param name="inputFormat">The <see cref="WaveFormat"/> format.</param>
        public WaveWriter(Stream output, WaveFormat inputFormat)
            : base(output, inputFormat)
        {
            if (OutStream.CanSeek == false)
            {
                throw new ArgumentException("output", Resources.IDS_WaveWriterArgumentException);
            }
            this.m_waveFormat = inputFormat;
            OutStream.Seek(WaveHeaderSize + 8, SeekOrigin.Current);
        }
        /// <summary>
        /// Closes the current <see cref="WaveWriter"/> and the underlying stream.
        /// </summary>
        public override void Close()
        {
            if (this.m_bClosed == false)
            {
                if (this.m_audioDataSize == 0)
                {
                    Seek(-(int)this.m_writtenBytes - (int)WaveHeaderSize - 8, SeekOrigin.Current);
                    this.m_audioDataSize = this.m_writtenBytes;
                    WriteWaveHeader();
                }
            }
            this.m_bClosed = true;
        }
        /// <summary>
        /// The written string is not a length-prefixed. <c>System.IO.BynaryWriter.Write</c> writes
        /// a length-prefixed string, <see cref="System.IO.BynaryWriter.Write"/> for details.
        /// </summary>
        /// <param name="value">String to write</param>
        public override void Write(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,
                    "value"));
            }
            Write(value.ToCharArray());
        }
        /// <summary>
        /// Writes a four-byte floating-point value to the current stream and advances the stream position by four bytes.
        /// Increases the written bytes field by four bytes.
        /// </summary>
        /// <param name="value">The four-byte floating-point value to write.</param>
        public override void Write(float value)
        {
            base.Write(value);
            this.m_writtenBytes += 4;
        }
        /// <summary>
        /// Writes an eight-byte unsigned integer to the current stream and advances the stream position by eight bytes.
        /// Increases the written bytes field by eight bytes.
        /// </summary>
        /// <param name="value">The eight-byte unsigned integer to write.</param>
        public override void Write(ulong value)
        {
            base.Write(value);
            this.m_writtenBytes += 8;
        }
        /// <summary>
        /// Writes an eight-byte signed integer to the current stream and advances the stream position by eight bytes.
        /// Increases the written bytes field by eight bytes.
        /// </summary>
        /// <param name="value">The eight-byte signed integer to write.</param>
        public override void Write(long value)
        {
            base.Write(value);
            this.m_writtenBytes += 8;
        }
        /// <summary>
        /// Writes a four-byte unsigned integer to the current stream and advances the stream position by four bytes.
        /// Increases the written bytes field by four bytes.
        /// </summary>
        /// <param name="value">The four-byte unsigned integer to write. </param>
        public override void Write(uint value)
        {
            base.Write(value);
            this.m_writtenBytes += 4;
        }
        /// <summary>
        /// Writes a four-byte signed integer to the current stream and advances the stream position by four bytes.
        /// Increases the written bytes field by four bytes.
        /// </summary>
        /// <param name="value">The four-byte signed integer to write.</param>
        public override void Write(int value)
        {
            base.Write(value);
            this.m_writtenBytes += 4;
        }
        /// <summary>
        /// Writes a two-byte unsigned integer to the current stream and advances the stream position by two bytes.
        /// Increases the written bytes field by two bytes.
        /// </summary>
        /// <param name="value">The two-byte unsigned integer to write.</param>
        public override void Write(ushort value)
        {
            base.Write(value);
            this.m_writtenBytes += 2;
        }
        /// <summary>
        /// Writes a two-byte signed integer to the current stream and advances the stream position by two bytes.
        /// Increases the written bytes field by two bytes.
        /// </summary>
        /// <param name="value">The two-byte signed integer to write.</param>
        public override void Write(short value)
        {
            base.Write(value);
            this.m_writtenBytes += 2;
        }
        /// <summary>
        /// Writes a decimal value to the current stream and advances the stream position by sixteen bytes.
        /// Increases the written bytes field by sixteen bytes.
        /// </summary>
        /// <param name="value"></param>
        public override void Write(decimal value)
        {
            base.Write(value);
            this.m_writtenBytes += 16;
        }
        /// <summary>
        /// Writes an eight-byte floating-point value to the current stream and advances the stream position by eight bytes.
        /// Increases the written bytes field by eight bytes.
        /// </summary>
        /// <param name="value">The eight-byte floating-point value to write.</param>
        public override void Write(double value)
        {
            base.Write(value);
            this.m_writtenBytes += 8;
        }
        /// <summary>
        /// Writes a section of a character array to the current stream, and advances the current position of the stream in accordance with the <b>Encoding</b> used and perhaps the specific characters being written to the stream.
        /// Increases the written bytes field by the count value.
        /// </summary>
        /// <param name="chars">A character array containing the data to write.</param>
        /// <param name="index">The starting point in buffer from which to begin writing.</param>
        /// <param name="count">The number of characters to write.</param>
        public override void Write(char[] chars, int index, int count)
        {
            base.Write(chars, index, count);
            this.m_writtenBytes += (uint)count;
        }
        /// <summary>
        /// Writes a character array to the current stream and advances the current position of the stream in accordance with the Encoding used and the specific characters being written to the stream.
        /// Increases the written bytes field by the chars length.
        /// </summary>
        /// <param name="chars">A character array containing the data to write.</param>
        public override void Write(char[] chars)
        {
            if (chars == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,
                    "chars"));
            }
            base.Write(chars);
            this.m_writtenBytes += (uint)chars.Length;
        }
        /// <summary>
        /// Writes a Unicode character to the current stream and advances the current position of the stream in accordance with the Encoding used and the specific characters being written to the stream.
        /// Increases the written bytes field by one byte.
        /// </summary>
        /// <param name="ch">The non-surrogate, Unicode character to write.</param>
        public override void Write(char ch)
        {
            base.Write(ch);
            this.m_writtenBytes += 1;
        }
        /// <summary>
        /// Writes a region of a byte array to the current stream.
        /// Increases the written bytes field by the count value.
        /// </summary>
        /// <param name="buffer">A byte array containing the data to write.</param>
        /// <param name="index">The starting point in buffer at which to begin writing.</param>
        /// <param name="count">The number of bytes to write.</param>
        public override void Write(byte[] buffer, int index, int count)
        {
            base.Write(buffer, index, count);
            this.m_writtenBytes += (uint)count;
        }
        /// <summary>
        /// Writes a byte array to the underlying stream.
        /// Increases the written bytes field by the buffer length.
        /// </summary>
        /// <param name="buffer">A byte array containing the data to write.</param>
        public override void Write(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,
                    "buffer"));
            }
            base.Write(buffer);
            this.m_writtenBytes += (uint)buffer.Length;
        }
        /// <summary>
        /// Writes a signed byte to the current stream and advances the stream position by one byte.
        /// Increases the written bytes field by one byte.
        /// </summary>
        /// <param name="value">The signed byte to write.</param>
        public override void Write(sbyte value)
        {
            base.Write(value);
            this.m_writtenBytes += 1;
        }
        /// <summary>
        /// Writes an unsigned byte to the current stream and advances the stream position by one byte.
        /// Increases the written bytes field by one byte.
        /// </summary>
        /// <param name="value">The unsigned byte to write.</param>
        public override void Write(byte value)
        {
            base.Write(value);
            this.m_writtenBytes += 1;
        }
        /// <summary>
        /// Writes a one-byte <b>Boolean</b> value to the current stream, with 0 representing <b>false</b> and 1 representing <b>true</b>.
        /// Increases the written bytes field by one byte.
        /// </summary>
        /// <param name="value">The <b>Boolean</b> value to write (0 or 1).</param>
        public override void Write(bool value)
        {
            base.Write(value);
            this.m_writtenBytes += 1;
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="WaveWriter"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><b>true</b> to release both managed and unmanaged resources; <b>false</b> to release only unmanaged resources</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                this.Flush();
                this.Close();
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// Writes the header into the wave file.
        /// </summary>
        protected void WriteWaveHeader()
        {
            Write(new char[] { 'R', 'I', 'F', 'F' });
            Write(this.m_audioDataSize + WaveHeaderSize);
            Write(new char[] { 'W', 'A', 'V', 'E' });
            Write(new char[] { 'f', 'm', 't', ' ' });
            Write(WaveFormatSize);
            Write(this.m_waveFormat.FormatTag);
            Write(this.m_waveFormat.Channels);
            Write(this.m_waveFormat.SamplesPerSec);
            Write(this.m_waveFormat.AvgBytesPerSec);
            Write(this.m_waveFormat.BlockAlign);
            Write(this.m_waveFormat.BitsPerSample);
            Write(this.m_waveFormat.Size);
            Write(new char[] { 'd', 'a', 't', 'a' });
            Write(this.m_audioDataSize);
            this.m_writtenBytes -= (WaveHeaderSize + 8);
        }
        #endregion
    }
}
