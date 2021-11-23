using System;
using System.Diagnostics;
using System.IO;

namespace Snakey.Chain_of_Responsibility
{
    public class FileLogger : Logger
    {
        public FileLogger(StreamWriter streamWriter)
        {
            _streamWriter = streamWriter;
        }
        public override void Log(MessageType type, string message)
        {
            if (type != MessageType.File)
                _next?.Log(type, message);
            else
            {
                _streamWriter.WriteLine($"[{DateTime.Now}] FILE: {message}");
                _streamWriter.Flush();
            }
        }
    }
}
