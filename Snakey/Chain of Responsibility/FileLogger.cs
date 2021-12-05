using System.IO;
using System.Runtime.CompilerServices;

namespace Snakey.Chain_of_Responsibility
{
    public class FileLogger : Logger
    {
        public FileLogger(StreamWriter streamWriter)
        {
            StreamWriter = streamWriter;
        }
        public override void Log(MessageType type, string message, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
        {
            if (type != MessageType.File)
                Next?.Log(type, message, file, member, line);
            else
            {
                var fileInfo = new FileInfo(message);
                StreamWriter.WriteLine("Loaded File:");
                StreamWriter.WriteLine($"\tFileName: {fileInfo.Name}");
                StreamWriter.WriteLine($"\tFileSize: {fileInfo.Length} bytes");
                StreamWriter.WriteLine($"\tDirectory: {fileInfo.DirectoryName}");
                StreamWriter.Flush();
            }
        }
    }
}
