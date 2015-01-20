// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System;
using System.Runtime.Serialization;

namespace BusinessLayer.Instruments
{
    [Serializable]
    // Important: This attribute is NOT inherited from Exception, and MUST be specified 
    // otherwise serialization will fail with a SerializationException stating that
    // "Type X in Assembly Y is not marked as serializable."
    public class BException : Exception
    {
        public BException() { }

        public BException(string message): base(message) { }

        public BException(string message, Exception innerException): base(message, innerException) { }

        // Without this constructor, deserialization will fail
        protected BException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
