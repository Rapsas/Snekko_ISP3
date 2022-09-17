namespace Snakey.Interpreter;

using Snakey.Chain_of_Responsibility;
using Snakey.Managers;
using Snakey.Models;
using System.Collections.Generic;
using System.Windows;

public class CommandExpression : IExpression
{
    private readonly string _commandName;
    private readonly List<IExpression> _params;

    public CommandExpression(string commandName, List<IExpression> @params)
    {
        _commandName = commandName;
        _params = @params;
    }

    // commands add (player|score) number
    // commands set score number
    public Value Execute()
    {
        if (_params.Count != 2)
            return null;

        var targetExpression = _params[0];
        var valueExpression = _params[1];

        var target = targetExpression.Execute();
        var value = valueExpression.Execute();

        if (target is null)
        {
            MessageBox.Show("Invalid  target");
            return null;
        }
        if (value is null)
        {
            MessageBox.Show("Invalid  value");
            return null;
        }

        switch (_commandName)
        {
            case "add":
                ExecuteAdd(target, value);
                break;

            case "set":
                ExecuteSet(target, value);
                break;

            default:
                GameState.Instance.Logger.Log(MessageType.Error, "Failed to match in switch case");
                MessageBox.Show("Invalid command");
                break;
        }

        return new Value() { String = "Command expression", IsString = true };
    }

    private static void ExecuteSet(Value target, Value value)
    {
        switch (target.Object)
        {
            case GameState state:
                state.Score = value.Number;
                break;
        }
    }

    private static void ExecuteAdd(Value target, Value value)
    {
        switch (target.Object)
        {
            case GameState state:
                state.Score += value.Number;
                break;
            case Snake player: // What about negative values?
                for (int i = 0; i < value.Number; i++)
                    player.Expand();

                player.IgnoreBodyCollisionWithHead = true;
                break;
        }
    }
}
