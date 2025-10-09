using System;
using System.Runtime.Serialization;

namespace BSE.Platten.FreeDb
{
	/// <summary>
    /// The exception that is thrown when a request to freedb does not match to the disk id.
	/// </summary>
	public class FreeDBMatchNoneException : Exception
	{
		#region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="FreeDBMatchNoneException"/>.
        /// </summary>
        public FreeDBMatchNoneException()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FreeDBMatchNoneException"/> class with its message string
        /// </summary>
        /// <param name="message">A String that describes the error. The content of message is intended
        /// to be understood by humans.</param>
		public FreeDBMatchNoneException(string message) : base(message)
		{
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="FreeDBMatchNoneException"/> class with a specified error
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">A String that describes the error. The content of message is intended
        /// to be understood by humans.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the
        /// innerException parameter is not a null reference (Nothing in Visual Basic), the current exception
        /// is raised in a catch block that handles the inner exception.</param>
		public FreeDBMatchNoneException(string message, Exception innerException) : base(message, innerException)
		{
		}
		#endregion

        #region MethodsProtected
        /// <summary>
        /// Initializes a new instance of the <see cref="FreeDBMatchNoneException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception
        /// being thrown.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        protected FreeDBMatchNoneException(SerializationInfo info,
         StreamingContext context)
            : base(info, context)
        {
        }
        #endregion
    }
}
