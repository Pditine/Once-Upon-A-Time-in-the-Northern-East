// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System;
using System.Collections.Generic;
using Data;
using GamePlay;
using PurpleFlowerCore.Utility;
using UnityEngine;

namespace Manager.Interface
{
    public class PublishManager : DdolSingletonMono<PublishManager>
    {
        [SerializeField] List<Title> titles = new();
        [SerializeField] List<Tag> tags = new();
        private PublishData CurrentLevelPublishData => DataManager.Instance.CurrentLevelData.publishData;
        private void OnEnable()
        {
            Init();
        }

        public void Init()
        {
            for (int i = 0; i < titles.Count; i++)
            {
                titles[i].ShowTitle(CurrentLevelPublishData.titles[i]);
            }
            for (int i = 0; i < tags.Count; i++)
            {
                tags[i].ShowTitle(CurrentLevelPublishData.tags[i]);
            }
        }

        public void HideTitles(int selectedIndex)
        {
            for (int i = 0; i < titles.Count; i++)
            {
                titles[i].HideTitle(i == selectedIndex);
            }
        }
        
        public void HideTags(int selectedIndex)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                tags[i].HideTag(i == selectedIndex);
            }
        }
        
        
        public void NextPage()
        {
            // DelayUtility.Delay(2, () =>
            // {
            //     InterfaceManager.Instance.NextPage();
            // });
            InterfaceManager.Instance.NextPage();
        }
    }
}