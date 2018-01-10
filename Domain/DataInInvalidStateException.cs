using System;

namespace Core
{
    public class DataInInvalidStateException : Exception
    {
        public DataInInvalidStateException()
        : base("The data has changed since editing started")
        {
            
        }
    }
}
