// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System;
using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class Tag : MonoBehaviour
    {
        [SerializeField] private Text text;
        private Button TheButton => GetComponent<Button>();
        private Image TheImage => GetComponent<Image>();
        private RevenueData _revenue;
        
        public void ShowTitle(TagInfo info)
        {
            // text.text = "<color=blue>#"+info.tag+"</color>";
            text.text = info.tag;
            text.color = Color.blue;
            _revenue = info.revenueData;
            TheButton.enabled = true;
            TheImage.color = new Color(TheImage.color.r, TheImage.color.g, TheImage.color.b, 1f);
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
            gameObject.SetActive(true);
        }

        public void HideTag(bool isSelect)
        {
            TheButton.enabled = false;
            if (isSelect) return;
            TheImage.color = new Color(TheImage.color.r, TheImage.color.g, TheImage.color.b, 0.5f);
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0.5f);
        }

        private void OnDisable()
        {
            gameObject.SetActive(false);
        }

        public void ChangeRevenue()
        {
            DataManager.Instance.ChangeRevenue(_revenue);
        }
    }
}