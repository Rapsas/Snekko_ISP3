using Common.Enums;
using Common.Utility;
using Snakey.Config;
using Snakey.States;
using Xunit;

namespace Snakey.Models.Tests
{
    public class SnakeTests
    {
        [StaFact]
        public void MakeServerPackageTest()
        {
            Snake player = new();

            var package = player.MakeServerPackage();

            Assert.True(package.SnakeHeadLocation.IsOverlaping(player.HeadLocation));
            Assert.True(package.SnakeBodyLocation == player.BodyParts);
            Assert.True(package.SnakeMovementDirection == player.CurrentMovementDirection);
            Assert.True(package.SnakeTailLocation.IsOverlaping(player.TailLocation));

            Assert.True(package.HeadColor.R == player.HeadColor.Color.R);
            Assert.True(package.HeadColor.G == player.HeadColor.Color.G);
            Assert.True(package.HeadColor.B == player.HeadColor.Color.B);

            Assert.True(package.BodyColor.R == player.BodyColor.Color.R);
            Assert.True(package.BodyColor.G == player.BodyColor.Color.G);
            Assert.True(package.BodyColor.B == player.BodyColor.Color.B);

            Assert.True(package.TailColor.R == player.TailColor.Color.R);
            Assert.True(package.TailColor.G == player.TailColor.Color.G);
            Assert.True(package.TailColor.B == player.TailColor.Color.B);
        }

        [StaFact]
        public void MoveTest()
        {
            Snake player = new();

            player.HeadLocation = new(0, 0);
            player.State = new UpState(player);
            player.Move();
            var newHeadLocation = new Vector2D(0, -Settings.CellSize);
            Assert.True(player.HeadLocation.IsOverlaping(newHeadLocation));

            player.HeadLocation = new(0, 0);
            player.State = new DownState(player);
            player.Move();
            newHeadLocation = new Vector2D(0, Settings.CellSize);
            Assert.True(player.HeadLocation.IsOverlaping(newHeadLocation));

            player.HeadLocation = new(0, 0);
            player.State = new LeftState(player);
            player.Move();
            newHeadLocation = new Vector2D(-Settings.CellSize, 0);
            Assert.True(player.HeadLocation.IsOverlaping(newHeadLocation));

            player.HeadLocation = new(0, 0);
            player.State = new RightState(player);
            player.Move();
            newHeadLocation = new Vector2D(Settings.CellSize, 0);
            Assert.True(player.HeadLocation.IsOverlaping(newHeadLocation));
        }

        [StaFact]
        public void ExpandTest()
        {
            Snake player = new();

            Assert.True(player.BodyParts.Count == 0);
            player.Expand();
            Assert.True(player.BodyParts.Count == 1);
        }

        [StaFact]
        public void ShrinkTest()
        {
            Snake player = new();

            Assert.True(player.BodyParts.Count == 0);
            player.Shrink();
            Assert.True(player.BodyParts.Count == 0);
            player.Expand();
            player.Expand();
            Assert.True(player.BodyParts.Count == 2);
            player.Shrink();
            Assert.True(player.BodyParts.Count == 1);
        }

        [StaFact]
        public void ResetTest()
        {
            Snake player = new();
            player.Move();
            player.Move();
            player.CurrentMovementDirection = MovementDirection.Down;
            player.Move();
            player.Expand();
            player.Expand();
            player.Expand();
            player.Move();
            player.Shrink();
            player.Move();
            player.IsDead = true;
            player.IsMovementLocked = true;

            player.Reset();

            Assert.False(player.IsDead);
            Assert.False(player.IsMovementLocked);

            var resetHeadLocation = new Vector2D(80, 80);
            Assert.True(player.HeadLocation.IsOverlaping(resetHeadLocation));

            var resetTailLocation = new Vector2D(-50, -50);
            Assert.True(player.TailLocation.IsOverlaping(resetTailLocation));

            Assert.True(player.CurrentMovementDirection == MovementDirection.Right);
            Assert.True(player.BodyParts.Count == 0);
        }

        [StaFact]
        public void SpeakTest()
        {
            Snake player = new();

            player.Speak("Hello");
            Assert.True((string)player.SnakeText.Content == "Hello");
        }

        [StaFact]
        public void ShutupTest()
        {
            Snake player = new();

            player.Speak("Hello");
            Assert.True((string)player.SnakeText.Content == "Hello");
            player.Shutup();
            Assert.True((string)player.SnakeText.Content == string.Empty);
        }
    }
}