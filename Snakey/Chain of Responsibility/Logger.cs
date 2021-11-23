using System.IO;

namespace Snakey.Chain_of_Responsibility
{
    public enum MessageType
    {
        Default,
        File,
        Server,
        Error
    }

    public abstract class Logger
    {
        protected Logger _next;
        protected StreamWriter _streamWriter;

        public Logger SetNext(Logger nextLogger)
        {
            _next = nextLogger;
            return nextLogger;
        }
        public abstract void Log(MessageType type, string message);
    }
}
