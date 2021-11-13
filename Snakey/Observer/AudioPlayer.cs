using Snakey.Models;
using Snakey.Snacks;
using System.Media;

namespace Snakey.Observer
{
    public class AudioPlayer : IObserver
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
            }
        }
    }
}
