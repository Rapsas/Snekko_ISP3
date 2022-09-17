namespace Snakey.Observer;

using Snakey.Config;
using Snakey.Models;
using Snakey.Snacks;
using System.IO;
using System.Media;

public class AudioPlayer : IObserver
{
    readonly SoundPlayer GoodSound;
    readonly SoundPlayer BadSound;
    readonly SoundPlayer MysterySound;

    public AudioPlayer()
    {
        GoodSound = new(Path.Combine(Settings.AssetFolder, "soundGood.wav"));
        BadSound = new(Path.Combine(Settings.AssetFolder, "soundBad.wav"));
        MysterySound = new(Path.Combine(Settings.AssetFolder, "soundMystery.wav"));
    }

    public void Update(Snack snack)
    {
        if (Settings.EnableSoundEffects)
            switch (snack.GetBaseType())
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
