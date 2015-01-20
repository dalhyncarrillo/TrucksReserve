// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System;
using System.Runtime.Serialization;

namespace ToolsLibrary
{
    [Serializable]
    // Important: This attribute is NOT inherited from Exception, and MUST be specified 
    // otherwise serialization will fail with a SerializationException stating that
    // "Type X in Assembly Y is not marked as serializable."
    internal class ToolsException : Exception
    {
        public ToolsException() { }

        public ToolsException(string message): base(message) { }

        public ToolsException(string message, Exception innerException): base(message, innerException) { }

        // Without this constructor, deserialization will fail
        protected ToolsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
