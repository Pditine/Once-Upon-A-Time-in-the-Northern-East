// //-------------------------------------------------
//  //copyright@ LiJianhao
//  //Licensed under the MIT License
//  //-------------------------------------------------

using System;
using Manager;
using PurpleFlowerCore;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class Setting : MonoBehaviour
    {
        [SerializeField] private Slider bgmSlider;
        [SerializeField] private Slider effectSlider;
        [SerializeField] private Button backToMainMenu;

        private void OnEnable()
        {
            Time.timeScale = 0;
            if(InterfaceManager.Instance.CurrentPageIndex != 0)
            {
                backToMainMenu.gameObject.SetActive(true);
            }else
            {
                backToMainMenu.gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void BackToMeinMenu()
        {
            InterfaceManager.Instance.TurnToPage(0);
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