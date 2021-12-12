﻿using Snakey.Config;
using Snakey.Models;
using Snakey.Snacks;
using System.IO;
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
            GoodSound = new(Path.Combine(Settings.AssetFolder, "soundGood.wav"));
            BadSound = new(Path.Combine(Settings.AssetFolder, "soundBad.wav"));
            MysterySound = new(Path.Combine(Settings.AssetFolder, "soundMystery.wav"));
        }
        //Some changes here
        public void Update(Snack snack)
        {
            if (Settings.EnableSoundEffects)//Why would you ever disable those sound effects
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
                        break;//This is very important man dont screw this up
                }
        }
    }
}
