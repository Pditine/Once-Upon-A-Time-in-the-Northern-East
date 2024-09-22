// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using PurpleFlowerCore;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.Interface
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Slider bgmSlider;
        [SerializeField] private Slider effectSlider;
        public void StartGame()
        {
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