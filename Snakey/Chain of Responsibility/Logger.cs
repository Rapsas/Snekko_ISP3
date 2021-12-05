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
        private Logger next;
        private StreamWriter streamWriter;

        protected Logger Next { get => next; set => next = value; }
        protected StreamWriter StreamWriter { get => streamWriter; set => streamWriter = value; }

        public Logger SetNext(Logger nextLogger)
        {
            Next = nextLogger;
            return nextLogger;
        }
        public abstract void Log(MessageType type, string message, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0);
    }
}
