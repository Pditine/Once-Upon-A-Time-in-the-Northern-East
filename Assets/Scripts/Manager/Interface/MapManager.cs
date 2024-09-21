// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.Interface
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField] private List<Button> levelButtons = new();
        
        private void OnEnable()
        {
            SetLevelVisible();
        }

        private void SetLevelVisible()
        {
            foreach (var button in levelButtons)
            {
                button.interactable = false;
            }
            levelButtons[LevelManager.Instance.CurrentLevelID].interactable = true;
        }

        public void EnterLevel()
        {
            var level = LevelManager.Instance.CurrentLevelData;
            InterfaceManager.Instance.NextPage(level.levelName);
        }

    }
}