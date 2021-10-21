using Common.Enums;
using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Config;
using Snakey.Managers;
using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snakey.Snacks
{
    class MysteryApple: MysterySnack
    {
        public override void TriggerEffect()
        {
            GameState.Instance.Score++;
            var choice = rnd.Next(11);
            if (choice > 5)
            {
                if (GameState.Instance.MultiplayerManager.Connection.State == HubConnectionState.Connected)
                    GameState.Instance.MultiplayerManager.Connection?.SendAsync("ChangePlayerSize", 2).Wait();
            }
            else
            {
                GameState.Instance.Player.Expand();
                GameState.Instance.Player.Expand();
            }
        }

        public override MysterySnack Clone()
        {
            var cloned = (MysteryApple)this.MemberwiseClone();
            cloned._body = new Rectangle() //it needs a different body otherwise gonna go crash cause 2 objects cant have same body
            {
                Stroke = this.Stroke,
                StrokeThickness = this.StrokeThickness,
                Width = Settings.CellSize,
                Height = Settings.CellSize,
                Fill = Brushes.IndianRed
            };
            return cloned;
        }

        public MysteryApple() : base()
        {
            _body = new Rectangle()
            {
                Stroke = this.Stroke,
                StrokeThickness = this.StrokeThickness,
                Width = Settings.CellSize,
                Height = Settings.CellSize,
                Fill = Brushes.IndianRed
            };
        }
        public override string ToString()
        {
            return this.rnd.GetHashCode().ToString();
        }

        public override MysterySnack DeepClone()
        {
            MysteryApple other = (MysteryApple)this.Clone(); //same as shallow clone, setting new random
            other.rnd = new Random();
            return other;
        }
    }
}
