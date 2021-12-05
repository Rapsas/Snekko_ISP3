using System.IO;
using System.Runtime.CompilerServices;

namespace Snakey.Chain_of_Responsibility
{
    public class ErrorLogger : Logger
    {
        public ErrorLogger(StreamWriter streamWriter)
        {
            StreamWriter = streamWriter;
        }
        public override void Log(MessageType type, string message, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
        {
            if (type != MessageType.Error)
                Next?.Log(type, message, file, member, line);
            else
            {
                StreamWriter.WriteLine("======================================");
                StreamWriter.WriteLine("ERROR AT: {0}_{1}({2}): {3}", Path.GetFileName(file), member, line, message);
                StreamWriter.WriteLine("======================================");
                StreamWriter.Flush();
            }
        }
    }
}
