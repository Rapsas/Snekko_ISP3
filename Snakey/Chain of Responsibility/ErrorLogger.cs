using System;
using System.Diagnostics;
using System.IO;

namespace Snakey.Chain_of_Responsibility
{
    public class ErrorLogger : Logger
    {
        public ErrorLogger(StreamWriter streamWriter)
        {
            _streamWriter = streamWriter;
        }
        public override void Log(MessageType type, string message)
        {
            if (type != MessageType.Error)
                _next?.Log(type, message);
            else
            {
                _streamWriter.WriteLine($"[{DateTime.Now}] ERROR: {message}");
                _streamWriter.Flush();
            }
        }
    }
}
