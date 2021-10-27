using Snakey.Adapter;
using Snakey.Snacks;
using System;
using System.Media;

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
