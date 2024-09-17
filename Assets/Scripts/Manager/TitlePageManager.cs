using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Manager
{
    public class TitlePageManager : MonoBehaviour
    {
        [SerializeField] private List<UIDocument> pages = new();
        private int _currentPageIndex = 0;
        
        public void StartGame()
        {
            NextPage();
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
