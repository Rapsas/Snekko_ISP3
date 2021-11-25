﻿using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Managers;
using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Visitor
{
    class GoodVisitor : IVisitor
    {
        public void VisitApple(Snack snack)
        {
            GameState.Instance.Player.Expand();
        }

        public void VisitLemon(Snack snack)
        {
            if (GameState.Instance.MultiplayerManager.Connection.State == HubConnectionState.Connected)
                GameState.Instance.MultiplayerManager.Connection?.SendAsync("ChangePlayerSize", -1).Wait();
        }
    }
}