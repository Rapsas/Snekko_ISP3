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
        private SoundPlayer GoodSound;
        private SoundPlayer BadSound;
        private SoundPlayer MysterySound;
        public AudioPlayer()
        {
            GoodSound = new("soundGood.wav");
            BadSound = new("soundBad.wav");
            MysterySound = new("soundMystery.wav");
        }

        public void Update(Snack snack)
        {
            switch (snack)
            {
                case BadSnack:
                    BadSound.Play();
                    break;
                case GoodSnack:
                    GoodSound.Play();
                    break;
                case MysterySnack:
                    MysterySound.Play();
                    break;
                default:
                    break;
            }
        }
    }
}
