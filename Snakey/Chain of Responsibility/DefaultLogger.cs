using System;
using System.Diagnostics;
using System.IO;

namespace Snakey.Chain_of_Responsibility
{
    public class DefaultLogger : Logger
    {
        public DefaultLogger(StreamWriter streamWriter)
        {
            _streamWriter = streamWriter;
        }
        public override void Log(MessageType type, string message)
        {
            if (type != MessageType.Default)
                _next?.Log(type, message);
            else
            {
                _streamWriter.WriteLine($"[{DateTime.Now}] DEFAULT: {message}");
                _streamWriter.Flush();
            }
        }
    }
}
