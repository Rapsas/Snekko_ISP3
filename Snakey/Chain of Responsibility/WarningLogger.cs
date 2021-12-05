using System.IO;
using System.Runtime.CompilerServices;

namespace Snakey.Chain_of_Responsibility
{
    public class WarningLogger : Logger
    {
        public WarningLogger(StreamWriter streamWriter)
        {
            StreamWriter = streamWriter;
        }
        public override void Log(MessageType type, string message, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
        {
            if (type != MessageType.Warning)
                Next?.Log(type, message, file, member, line);
            else
            {
                StreamWriter.WriteLine($"WARNING FROM: {Path.GetFileName(file)}({line}): {message}");
                StreamWriter.Flush();
            }
        }
    }
}
