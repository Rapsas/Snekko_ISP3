using System.IO;
using System.Runtime.CompilerServices;

namespace Snakey.Chain_of_Responsibility
{
    public enum MessageType
    {
        Default,
        File,
        Warning,
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
        public abstract void Log(MessageType type, string message, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0);
    }
}
