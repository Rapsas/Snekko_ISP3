using Snakey.Models;
using Snakey.Snacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Snakey.Adapter;

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

        public void Update(SnackAdapter snack)
        {
            Type type = snack.GetSnackType();

            if (type == typeof(BadSnack))
                BadSound.Play();
            else if (type == typeof(GoodSnack))
                GoodSound.Play();
            else if (type == typeof(MysterySnack))
                MysterySound.Play();
        }
    }
}
