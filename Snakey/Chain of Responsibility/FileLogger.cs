namespace Snakey.Chain_of_Responsibility;

using System.IO;
using System.Runtime.CompilerServices;

public class FileLogger : Logger
{
    public FileLogger(StreamWriter streamWriter)
    {
        _streamWriter = streamWriter;
    }
    public override void Log(MessageType type, string message, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
    {
        if (type != MessageType.File)
        {
            _next?.Log(type, message, file, member, line);
            return;
        }

        var fileInfo = new FileInfo(message);
        _streamWriter.WriteLine("Loaded File:");
        _streamWriter.WriteLine($"\tFileName: {fileInfo.Name}");
        _streamWriter.WriteLine($"\tFileSize: {fileInfo.Length} bytes");
        _streamWriter.WriteLine($"\tDirectory: {fileInfo.DirectoryName}");
        _streamWriter.Flush();
    }
}
