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
            DataManager.Instance.ResetLevel();
            InterfaceManager.Instance.NextPage();
        }

        public void Resume()
        {
            DataManager.Instance.ResetData();
            InterfaceManager.Instance.NextPage();
        }
        
        public void Quit()
        {
            Application.Quit();
        }
    }
}