using System.IO;
using System.Runtime.CompilerServices;

namespace Snakey.Chain_of_Responsibility
{
    public class DefaultLogger : Logger
    {
        public DefaultLogger(StreamWriter streamWriter)
        {
            StreamWriter = streamWriter;
        }
        public override void Log(MessageType type, string message, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
        {
            if (type != MessageType.Default)
                Next?.Log(type, message, file, member, line);
            else
            {
                StreamWriter.WriteLine(message);
                StreamWriter.Flush();
            }
        }
    }
}
