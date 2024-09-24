using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class Title : MonoBehaviour
    {
        [SerializeField] private Text text;
        public Button TheButton => GetComponent<Button>();
        private RevenueData _revenue;
        
        public void ShowTitle(TitleInfo info)
        {
            text.text = info.title;
            _revenue = info.revenueData;
        }

        public void AddRevenue()
        {
            
        }
    }
}