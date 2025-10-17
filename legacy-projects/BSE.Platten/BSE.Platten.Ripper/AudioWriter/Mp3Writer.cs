using BSE.Platten.Ripper.Lame;
using BSE.Platten.Ripper.Properties;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using static BSE.Platten.Ripper.Lame.LameEncDll;

namespace BSE.Platten.Ripper.AudioWriters
{
    /// <summary>
    /// Writes mp3 types in binary to a stream and supports writing strings in a specific mp3 encoding.
    /// </summary>
    public class MP3Writer : AudioWriter
    {
        private IntPtr _lame;
        private byte[] _mp3Buffer;
        private int _channels;
        private int _sampleRate;

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
            : base(output, inputFormat)
        {
            _channels = inputFormat.Channels; // Use actual channel count from input format
            _sampleRate = inputFormat.SamplesPerSec; // Use actual sample rate from input format

            _lame = NativeMethods.lame_init();
            NativeMethods.lame_set_in_samplerate(_lame, _sampleRate);
            NativeMethods.lame_set_num_channels(_lame, _channels);
            NativeMethods.lame_set_mode(_lame, mp3Configuration.Format.LHV1.Mode);
            NativeMethods.lame_set_brate(_lame, mp3Configuration.Format.LHV1.Bitrate); // kbps
            NativeMethods.lame_init_params(_lame);

            _mp3Buffer = new byte[_sampleRate];
        }
        /// <summary>
        /// Closes the current <see cref="MP3Writer"/> and the underlying stream.
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public override void Close()
        {
            int mp3Bytes = NativeMethods.lame_encode_flush(_lame, _mp3Buffer, _mp3Buffer.Length);
            if (mp3Bytes > 0)
            {
                base.Write(_mp3Buffer, 0, mp3Bytes);
            }
            NativeMethods.lame_close(_lame);
            base.Close();
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

            // Convert byte[] to short[] for PCM 16 - bit
            int samples = count / 2;
            short[] pcm = new short[samples];
            Buffer.BlockCopy(buffer, index, pcm, 0, count);

            int mp3Bytes = NativeMethods.lame_encode_buffer_interleaved(
                _lame, pcm, samples / _channels, _mp3Buffer, _mp3Buffer.Length);

            if (mp3Bytes > 0)
            {
                base.Write(_mp3Buffer, 0, mp3Bytes);
            }
        }
    }
}
