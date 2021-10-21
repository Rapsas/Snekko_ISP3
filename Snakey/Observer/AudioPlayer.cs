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
        readonly SoundPlayer GoodSound;
        readonly SoundPlayer BadSound;
        readonly SoundPlayer MysterySound;

        public AudioPlayer()
        {
            GoodSound = new("../../../assets/soundGood.wav");
            BadSound = new("../../../assets/soundBad.wav");
            MysterySound = new("../../../assets/soundMystery.wav");
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
