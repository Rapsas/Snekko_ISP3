using Snakey.Chain_of_Responsibility;
using Snakey.Managers;

namespace Snakey.Interpreter
{
    public class ObjectExpression : IExpression
    {
        private string _objectName;

        public ObjectExpression(string objectName)
        {
            _objectName = objectName;
        }

        public Value Execute()
        {
            switch (_objectName)
            {
                case "player":
                    return new Value() { Object = GameState.Instance.Player, IsObject = true };
                case "secondPlayer":
                    return new Value() { Object = GameState.Instance.SecondPlayer, IsObject = true };
                case "score":
                    return new Value() { Object = GameState.Instance, IsObject = true };
                default:
                    GameState.Instance.Logger.Log(MessageType.Error, "Failed to match an object in switch");
                    return null;
            }
        }
    }
}