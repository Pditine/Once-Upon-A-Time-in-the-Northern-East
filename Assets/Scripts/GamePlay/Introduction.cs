// //-------------------------------------------------
//  //copyright@ LiJianhao
//  //Licensed under the MIT License
//  //-------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections;
using PurpleFlowerCore.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class Introduction : MonoBehaviour
    {
        [SerializeField]private List<Text> introductionTexts;
        [SerializeField]private Image introductionImage;
        public void ShowTexts()
        {
            StartCoroutine(DoShowTexts());
        }

        private IEnumerator DoShowTexts()
        {
            FadeUtility.FadeInAndStay(introductionImage,100);
            yield return new WaitForSeconds(3);
            foreach (var introductionText in introductionTexts)
            {
                FadeUtility.FadeInAndStay(introductionText, 80);
                yield return new WaitForSeconds(3);
            }
            yield return new WaitForSeconds(3);
            HideTexts();
        }
        
        private void HideTexts()
        {
            FadeUtility.FadeOut(introductionImage,80);
            foreach (var introductionText in introductionTexts)
            {
                FadeUtility.FadeOut(introductionText, 80);
            }
        }
    }
}