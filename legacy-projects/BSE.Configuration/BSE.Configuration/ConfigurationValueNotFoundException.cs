using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace BSE.Configuration
{
    [SerializableAttribute]
    public class ConfigurationValueNotFoundException : Exception
    {
        #region MethodsPublic

        public ConfigurationValueNotFoundException()
        {
        }

        public ConfigurationValueNotFoundException(string message)
            : base(message)
        {
        }

        public ConfigurationValueNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ConfigurationValueNotFoundException(SerializationInfo info,
         StreamingContext context)
            : base(info, context)
        {
            // Implement type-specific serialization constructor logic.
        }

        #endregion
    }
}
