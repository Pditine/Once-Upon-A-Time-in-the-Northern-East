// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using GamePlay;
using PurpleFlowerCore;
using PurpleFlowerCore.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.Interface
{
    public class AudienceReplyManager : MonoBehaviour
    {
        [SerializeField] private List<Item> items = new();
        [SerializeField] private AudienceReplyBackground background;
        [SerializeField] private Device device;
        [SerializeField] private Text finishText;
        [SerializeField] private float waitTime1 = 2;
        [SerializeField] private float waitTime2 = 15;
        private AudienceReplyData CurrentAudienceReplyData => DataManager.Instance.CurrentLevelData.audienceReplyData;
        private int PublishIndex => DataManager.Instance.GetPublishIndex();
        private void OnEnable()
        {
            Init();
        }

        private void Init()
        {
            PFCLog.Info("AudienceReplyManager", $"PublishIndex:{PublishIndex}");
            background.Init();
            var itemData = CurrentAudienceReplyData.GetAudienceReplyItemData();
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Init(itemData[i]);
            }
            device.Init();
            finishText.enabled = false;
        }

        public void ShowItems()
        {
            background.ShowWhitePanel();
            device.Disappear();
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Show();
            }
        }
        
        public void TryFinish()
        {
            foreach (var item in items)
            {
                if (!item.Clicked) return;
            }
            ShowFinishText();
        }

        private void ShowFinishText()
        {
            foreach (var item in items)
            {
                item.Disappear();
            }
            finishText.text = CurrentAudienceReplyData.finalText;
            FadeUtility.FadeInAndStay(finishText,80);
            DelayUtility.Delay(waitTime2, NextPage);
        }
        
        private void NextPage()
        {
            InterfaceManager.Instance.NextPage();
        }
    }
}