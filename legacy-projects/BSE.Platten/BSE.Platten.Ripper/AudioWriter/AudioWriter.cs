using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using BSE.Platten.Ripper.Properties;

namespace BSE.Platten.Ripper.AudioWriters
{
    /// <summary>
    /// Writes <see cref="WaveFormat"/> types in binary to a stream and supports writing strings in a specific
    /// encoding.
    /// </summary>
    public abstract class AudioWriter : BinaryWriter
    {
        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="WaveFormat"/> input format.
        /// </summary>
        protected WaveFormat InputFormat
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="AudioWriter"/> class based on the supplied stream and
        /// a specific character encoding.
        /// </summary>
        /// <param name="output">The supplied stream.</param>
        /// <param name="inputDataFormat">The <see cref="WaveFormat"/> input data format</param>
        protected AudioWriter(Stream output, WaveFormat inputDataFormat)
            : base(output, System.Text.Encoding.ASCII)
        {
            this.InputFormat = inputDataFormat;
        }
        /// <summary>
        /// Initializes a new instance of the AudioWriter class that writes to a stream.
        /// </summary>
        /// <param name="output">The supplied stream.</param>
        /// <param name="configuration">The <see cref="WaveWriterConfiguration"/> configuration</param>
        protected AudioWriter(Stream output, WaveWriterConfiguration configuration)
            : this(output, configuration.WaveFormat)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,
                    "configuration"));
            }
        }
        /// <summary>
        /// Releases the unmanaged resources used by the BinaryWriter and
        /// optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release
        /// only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                this.Flush();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
