using Snakey.Models;
using Snakey.Snacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Snakey.Observer
{
    class AudioPlayer : IObserver
    {
        public void Update(Snack snack)
        {
            switch (snack)
            {
                case BadSnack:
                    SystemSounds.Beep.Play();
                    break;
                case GoodSnack:
                    SystemSounds.Asterisk.Play();
                    break;
                case MysterySnack:
                    SystemSounds.Question.Play();
                    break;
                default:
                    break;
            }
        }
    }
}
