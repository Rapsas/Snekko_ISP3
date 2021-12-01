using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;

namespace Snakey.Mediator
{
    public interface IMediator
    {
        Snack Send(FoodType foodType, EffectType effectType);
    }
}
