﻿namespace Snakey.Chain_of_Responsibility;

using System.IO;
using System.Runtime.CompilerServices;

public class WarningLogger : Logger
{
    public WarningLogger(StreamWriter streamWriter)
    {
        _streamWriter = streamWriter;
    }
    public override void Log(MessageType type, string message, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
    {
        if (type != MessageType.Warning)
        {
            _next?.Log(type, message, file, member, line);
            return;
        }
        _streamWriter.WriteLine($"WARNING FROM: {Path.GetFileName(file)}({line}): {message}");
        _streamWriter.Flush();
    }
}
