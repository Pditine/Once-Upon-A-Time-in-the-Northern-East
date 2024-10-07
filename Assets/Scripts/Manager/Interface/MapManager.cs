// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System;
using System.Collections.Generic;
using GamePlay;
using PurpleFlowerCore;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.Interface
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField] private List<Button> levelButtons = new();
        [SerializeField] private Introduction introduction;
        private void OnEnable()
        {
            SetLevelVisible();
            if(DataManager.Instance.CurrentLevelID == 0)
                introduction.ShowTexts();
        }

        private void SetLevelVisible()
        {
            foreach (var button in levelButtons)
            {
                button.interactable = false;
            }
            PFCLog.Info("MapManager",DataManager.Instance.CurrentLevelID);
            levelButtons[DataManager.Instance.CurrentLevelID].interactable = true;
        }

        public void EnterLevel()
        {
            var level = DataManager.Instance.CurrentLevelData;
            InterfaceManager.Instance.NextPage(level.levelName);
        }

    }
}