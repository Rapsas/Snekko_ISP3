using System;
using System.Diagnostics;
using System.IO;

namespace Snakey.Chain_of_Responsibility
{
    public class ServerLogger : Logger
    {
        public ServerLogger(StreamWriter streamWriter)
        {
            _streamWriter = streamWriter;
        }
        public override void Log(MessageType type, string message)
        {
            if (type != MessageType.Server)
                _next?.Log(type, message);
            else
            {
                _streamWriter.WriteLine($"[{DateTime.Now}] Server: {message}");
                _streamWriter.Flush();
            }
        }
    }
}
