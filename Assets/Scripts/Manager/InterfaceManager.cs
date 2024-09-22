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
    public class InterfaceManager : DdolSingletonMono<InterfaceManager>
    {
        [SerializeField] private List<GameObject> interfaces = new();
        [SerializeField] private Image blackPanel;
        [SerializeField] private Text title;
        private int _currentPageIndex = 0;

        public void NextPage(string theTitle = null)
        {
            if (theTitle != null)
            {
                title.text = theTitle;
                FadeUtility.FadeInAndStay(title,80);
            }
            FadeUtility.FadeInAndStay(blackPanel,80, () =>
            {
                interfaces[_currentPageIndex].gameObject.SetActive(false);
                _currentPageIndex++;
                if (_currentPageIndex >= interfaces.Count)
                {
                    _currentPageIndex = 0;
                }
                interfaces[_currentPageIndex].gameObject.SetActive(true);
                if (theTitle != null)
                {
                    DelayUtility.Delay(3, () =>
                    {
                        FadeUtility.FadeOut(blackPanel, 80);
                        FadeUtility.FadeOut(title,80);
                    });
                }
                else
                {
                    FadeUtility.FadeOut(blackPanel, 80);
                }
            });
            PFCLog.Info("interface",$"next page:{_currentPageIndex}");
        }
        
    }
}
