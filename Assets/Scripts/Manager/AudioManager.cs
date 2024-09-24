// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System;
using System.Collections.Generic;
using PurpleFlowerCore;
using PurpleFlowerCore.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class AudioManager : DdolSingletonMono<AudioManager>
    {
        [SerializeField] private string startBGM = "StreetOchestraBGM";
        [SerializeField] private List<AudioClip> audios = new();
        
        private void Start()
        {
            PlayBGM(startBGM);
        }

        public void PlayBGM(string audioName)
        {
            PFCLog.Info("Audio",audioName);
            var theAudio = audios.Find(a => a.name == audioName);
            if (theAudio is null) return;
            AudioSystem.PlayBGM(theAudio);
        }

        public void PlayEffect(string audioName)
        {
            PFCLog.Info("Audio",audioName);
            var theAudio = audios.Find(a => a.name == audioName);
            if (theAudio is null) return;
            AudioSystem.PlayEffect(theAudio,transform);
        }

    }
}