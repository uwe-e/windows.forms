using System;
using System.IO;
using System.Security.Permissions;
using System.Globalization;
using BSE.Platten.Ripper.Properties;
using BSE.Platten.Ripper.Lame;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Ripper.AudioWriters
{
	/// <summary>
    /// Writes mp3 types in binary to a stream and supports writing strings in a specific mp3 encoding.
	/// </summary>
	public class MP3Writer :  AudioWriter
	{
		#region FieldsPrivate
		
		private bool m_bClosed;
        private BeConfiguration m_mp3Configuration;
		private byte[] m_inBuffer;
		private byte[] m_outBuffer;
        private uint m_iLameStream;
		private uint m_iInputSamples;
		private uint m_iOutBufferSize;
		private int m_iInBufferPosition;
		
		#endregion

		#region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="MP3Writer"/> class based on the supplied stream using ASCII as the encoding for strings and the given input format.
        /// </summary>
        /// <param name="output">The output stream.</param>
        /// <param name="inputDataFormat">The <see cref="WaveFormat"/> input data format.</param>
        public MP3Writer(Stream output, WaveFormat inputDataFormat)
            : this(output, inputDataFormat, new BeConfiguration(inputDataFormat))
		{
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="MP3Writer"/> class based on the supplied stream using ASCII as the encoding for strings and the given configuration.
        /// </summary>
        /// <param name="output">The output stream.</param>
        /// <param name="configuration">The <see cref="MP3WriterConfiguration"/> configuration.</param>
        public MP3Writer(Stream output, MP3WriterConfiguration configuration)
            : this(output, configuration.WaveFormat, configuration.BeConfiguration)
		{
            if (configuration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "configuration"));
            }
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="MP3Writer"/> class based on the supplied stream using ASCII as the encoding for strings with the given input format and the mp3 configuration.
        /// </summary>
        /// <param name="output">The output stream.</param>
        /// <param name="inputFormat">The <see cref="WaveFormat"/> input format.</param>
        /// <param name="mp3Configuration">The <see cref="BeConfiguration"/> configuration.</param>
        public MP3Writer(Stream output, WaveFormat inputFormat, BeConfiguration mp3Configuration)
			:base(output, inputFormat)
		{
			try
			{
				this.m_mp3Configuration = mp3Configuration;
				uint LameResult = LameEncDll.NativeMethods.beInitStream(this.m_mp3Configuration, ref this.m_iInputSamples, ref this.m_iOutBufferSize, ref this.m_iLameStream);
				if ( LameResult != LameEncDll.BE_ERR_SUCCESSFUL)
				{
					throw new ApplicationException(string.Format(CultureInfo.InvariantCulture, "Lame_encDll.beInitStream failed with the error code {0}", LameResult));
				}
				this.m_inBuffer = new byte[this.m_iInputSamples * 2]; //Input buffer is expected as short[]
				this.m_outBuffer = new byte[m_iOutBufferSize];
			}
			catch
			{
				base.Close();
				throw;
			}
		}
        /// <summary>
        /// Closes the current <see cref="MP3Writer"/> and the underlying stream.
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public override void Close()
		{
			if (this.m_bClosed == false)
			{
				try
				{
					uint iEncodedSize = 0;
					if ( this.m_iInBufferPosition > 0)
					{
                        if ( LameEncDll.EncodeChunk(this.m_iLameStream, this.m_inBuffer, 0, (uint)this.m_iInBufferPosition, this.m_outBuffer, ref iEncodedSize) == LameEncDll.BE_ERR_SUCCESSFUL )
						{
							if ( iEncodedSize > 0)
							{
                                Write(this.m_outBuffer, 0, (int)iEncodedSize);
							}
						}
					}
					iEncodedSize = 0;
                    if (LameEncDll.NativeMethods.beDeinitStream(this.m_iLameStream, this.m_outBuffer, ref iEncodedSize) == LameEncDll.BE_ERR_SUCCESSFUL)
					{
						if ( iEncodedSize > 0)
						{
                            Write(this.m_outBuffer, 0, (int)iEncodedSize);
						}
					}
				}
				finally
				{
                    LameEncDll.NativeMethods.beCloseStream(this.m_iLameStream);
				}
			}
			this.m_bClosed = true;
		}
		/// <summary>
        /// Writes a region of a byte array to the current stream.
		/// </summary>
        /// <param name="buffer">A byte array containing the data to write.</param>
        /// <param name="index">The starting point in buffer at which to begin writing.</param>
        /// <param name="count">The number of bytes to write.</param>
        [SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public override void Write(byte[] buffer, int index, int count)
		{
			int iToCopy = 0;
			uint iEncodedSize = 0;
			uint iLameResult;
			while (count > 0)
			{
				if ( this.m_iInBufferPosition > 0 ) 
				{
					iToCopy = Math.Min(count, this.m_inBuffer.Length - this.m_iInBufferPosition);
					Buffer.BlockCopy(buffer, index, this.m_inBuffer, this.m_iInBufferPosition , iToCopy);
					this.m_iInBufferPosition += iToCopy;
					index += iToCopy;
					count -= iToCopy;
					if (this.m_iInBufferPosition >= this.m_inBuffer.Length)
					{
						this.m_iInBufferPosition = 0;
						if ( (iLameResult = LameEncDll.EncodeChunk(this.m_iLameStream, this.m_inBuffer, this.m_outBuffer, ref iEncodedSize)) == LameEncDll.BE_ERR_SUCCESSFUL )
						{
							if ( iEncodedSize > 0)
							{
								base.Write(this.m_outBuffer, 0, (int)iEncodedSize);
							}
						}
						else
						{
							throw new ApplicationException(
                                string.Format(
                                CultureInfo.InvariantCulture,
                                "Lame.LameEncDll.EncodeChunk failed with the error code {0}",
                                iLameResult));
						}
					}
				}
				else
				{
					if (count >= this.m_inBuffer.Length)
					{
						if ( (iLameResult = LameEncDll.EncodeChunk(this.m_iLameStream, buffer, index, (uint)this.m_inBuffer.Length, this.m_outBuffer, ref iEncodedSize)) == LameEncDll.BE_ERR_SUCCESSFUL )
						{
							if ( iEncodedSize > 0)
							{
								base.Write(this.m_outBuffer, 0, (int)iEncodedSize);
							}
						}
						else
						{
							throw new ApplicationException(
                                string.Format(
                                CultureInfo.InvariantCulture,
                                "Lame.LameEncDll.EncodeChunk failed with the error code {0}",
                                iLameResult)); 
						}
						count -= this.m_inBuffer.Length;
						index += this.m_inBuffer.Length;
					}
					else
					{
						Buffer.BlockCopy(buffer, index, this.m_inBuffer, 0, count);
						this.m_iInBufferPosition = count;
						index += count;
						count = 0;
					}
				}
			}
		}
		#endregion
    }
}
