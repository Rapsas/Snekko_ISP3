namespace Snakey.Chain_of_Responsibility;

using System.IO;
using System.Runtime.CompilerServices;

public class ErrorLogger : Logger
{
    public ErrorLogger(StreamWriter streamWriter)
    {
        _streamWriter = streamWriter;
    }
    public override void Log(MessageType type, string message, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
    {
        if (type != MessageType.Error)
        {
            _next?.Log(type, message, file, member, line);
            return;
        }
        _streamWriter.WriteLine("======================================");
        _streamWriter.WriteLine("ERROR AT: {0}_{1}({2}): {3}", Path.GetFileName(file), member, line, message);
        _streamWriter.WriteLine("======================================");
        _streamWriter.Flush();
    }
}
