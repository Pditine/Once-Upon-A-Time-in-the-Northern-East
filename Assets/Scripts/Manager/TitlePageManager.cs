// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System;
using System.Collections.Generic;
using PurpleFlowerCore;
using UnityEngine;
using UnityEngine.UIElements;

namespace Manager
{
    public class TitlePageManager : MonoBehaviour
    {
        [SerializeField] private List<UIDocument> pages = new();
        private int _currentPageIndex = 0;
        
        private void OnDisable()
        {
            EventSystem.EventTrigger("LevelOver");
        }
        
        public void StartGame()
        {
            NextPage();
        }
        
        public void ExitGame()
        {
            Application.Quit();
        }

        private void NextPage()
        {
            pages[_currentPageIndex].gameObject.SetActive(false);
            _currentPageIndex++;
            if (_currentPageIndex >= pages.Count)
            {
                _currentPageIndex = 0;
            }
            pages[_currentPageIndex].gameObject.SetActive(true);
        }


        
        
    }
}
