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
        public int CurrentPageIndex => _currentPageIndex;
        
        public bool canTurnPage = true;
        
        public void TurnToPage(int index)
        {
            // if (!canTurnPage) return;
            // canTurnPage = false;
            if(index < 0 || index >= interfaces.Count) return;
            // FadeUtility.FadeInAndStay(blackPanel,80, () =>
            // {
                interfaces[_currentPageIndex].gameObject.SetActive(false);
                _currentPageIndex = index;
                interfaces[_currentPageIndex].gameObject.SetActive(true);
                PFCLog.Info("interface",$"turn to page:{_currentPageIndex}");
            //     FadeUtility.FadeOut(blackPanel, 80,()=>
            //     {
            //         canTurnPage = true;
            //     });
            // });

        }

        public void NextPage(string theTitle = null)
        {
            if(canTurnPage == false) return;
            canTurnPage = false;
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
                        FadeUtility.FadeOut(blackPanel, 80,()=>
                        {
                            canTurnPage = true;
                        });
                        FadeUtility.FadeOut(title,80);
                    });
                }
                else
                {
                    FadeUtility.FadeOut(blackPanel, 80,()=>
                    {
                        canTurnPage = true;
                    });
                }
            });
            PFCLog.Info("interface",$"next page:{_currentPageIndex}");
        }
        
    }
}
