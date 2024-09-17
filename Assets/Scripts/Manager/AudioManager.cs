#region PFC
// //-------------------------------------------------
// //copyright@ LiJianhao
// //-------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using PurpleFlowerCore;
using PurpleFlowerCore.Utility;
using UnityEngine;

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

            var theAudio = audios.Find(a => a.name == audioName);
            if (theAudio is null) return;
            AudioSystem.PlayBGM(theAudio);
        }

        public void PlayEffect(string audioName)
        {
            Debug.Log(111);
            var theAudio = audios.Find(a => a.name == audioName);
            if (theAudio is null) return;
            AudioSystem.PlayEffect(theAudio,transform);
        }

    }
}