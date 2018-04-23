using System;

namespace ZaklepToClientLibrary.Exceptions
{
    public class ClientException : Exception
    {
        public string Code { get; }

        public ClientException()
        {
            
        }

        public ClientException(string code)
        {
            Code = code;
        }

        public ClientException(string message, params object[] args) : this(string.Empty, message, args)
        {
            
        }

        public ClientException(string code, string message, params object[] args) : this(null, string.Empty, message, args)
        {
            
        }

        public ClientException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
            
        }

        public ClientException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}