// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------
using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class Title : MonoBehaviour
    {
        [SerializeField] private Text text;
        private Button TheButton => GetComponent<Button>();
        private Image TheImage => GetComponent<Image>();
        private RevenueData _revenue;
        private float _publishCoefficient;
        
        public void ShowTitle(TitleInfo info)
        {
            text.text = info.title;
            _revenue = info.revenueData;
            _publishCoefficient = info.publishCoefficient;
            TheButton.enabled = true;
            TheImage.color = new Color(TheImage.color.r, TheImage.color.g, TheImage.color.b, 1f);
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
            gameObject.SetActive(true);
        }
        
        public void HideTitle(bool isSelect)
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
            DataManager.Instance.ChangePublishCoefficient(_publishCoefficient);
        }
    }
}