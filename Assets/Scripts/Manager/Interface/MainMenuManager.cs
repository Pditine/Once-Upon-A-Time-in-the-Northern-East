// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System;
using Pditine.Component;
using PurpleFlowerCore;
using PurpleFlowerCore.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.Interface
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Slider bgmSlider;
        [SerializeField] private Slider effectSlider;
        [SerializeField] private Button resumeButton;

        private void OnEnable()
        {
            DelayUtility.DelayFrame(1, InitResumeButton);
        }
        private void InitResumeButton()
        {
            if(DataManager.Instance.CurrentLevelID == 0)
            {
                resumeButton.interactable = false;
                resumeButton.GetComponent<ButtonEffect_Scale>().enabled = false;
            }else
            {
                resumeButton.interactable = true;
                resumeButton.GetComponent<ButtonEffect_Scale>().enabled = true;
            }
        }

        public void StartGame()
        {
            DataManager.Instance.ResetData();
            InterfaceManager.Instance.NextPage();
        }

        public void Resume()
        {
            InterfaceManager.Instance.NextPage();
        }
        
        public void Quit()
        {
            Application.Quit();
        }
        
        public void OnBGMChange()
        {
            PFCLog.Info("BGM",bgmSlider.value);
            AudioSystem.BGMVolume = bgmSlider.value;
        }
        
        public void OnEffectChange()
        {
            PFCLog.Info("Effect",effectSlider.value);
            AudioSystem.EffectVolume = effectSlider.value;
        }
    }
}