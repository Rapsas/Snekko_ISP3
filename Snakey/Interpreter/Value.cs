namespace Snakey.Interpreter;

using System.Collections.Generic;

public class Value
{
    public int Number { get; set; }
    public string String { get; set; }
    public List<IExpression> List { get; set; }
    public object Object { get; set; }
    public bool IsNumber { get; set; }
    public bool IsString { get; set; }
    public bool IsList { get; set; }
    public bool IsObject { get; set; }
}
