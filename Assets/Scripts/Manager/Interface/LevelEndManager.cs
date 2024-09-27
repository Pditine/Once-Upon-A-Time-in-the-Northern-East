// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System.Globalization;
using PurpleFlowerCore.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.Interface
{
    public class LevelEndManager : MonoBehaviour
    {
        [SerializeField] private Text viewNum;
        [SerializeField] private Text followNum;
        [SerializeField] private Text rewardNum;
        [SerializeField] private Text continueText;
        private RevenueData CurrentRevenueData => DataManager.Instance.CurrentRevenueData;

        private void OnEnable()
        {
            Init();
        }

        private void Init()
        {
            InitData();
            InitContinue();
        }
        
        private void InitData()
        {
            viewNum.text = $"view:{CurrentRevenueData.viewNum.ToString(CultureInfo.InvariantCulture)}k";
            followNum.text = $"follow:{CurrentRevenueData.followNum.ToString(CultureInfo.InvariantCulture)}k";
            rewardNum.text = $"reward:{CurrentRevenueData.rewardNum.ToString(CultureInfo.InvariantCulture)}k";
        }

        private void InitContinue()
        {
            continueText.text = DataManager.Instance.BeyondExpectedRevenue() ? "你过关!" : "你没过!";
        }
        
        public void Continue()
        {
            if(DataManager.Instance.BeyondExpectedRevenue())
                Win();
            else
                Lose();
        }
        
        private void Win()
        {
            DataManager.Instance.PassLevel();
            InterfaceManager.Instance.NextPage();
        }
        
        private void Lose()
        {
            DataManager.Instance.ResetData();
            InterfaceManager.Instance.NextPage();
        }
    }
}