// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using PurpleFlowerCore;
using PurpleFlowerCore.Utility;
using UnityEngine;
using UnityEngine.Serialization;

namespace Manager
{
    public class DataManager : DdolSingletonMono<DataManager>
    {
        [SerializeField] private List<LevelData> levelData = new();
        public List<LevelData> LevelData => levelData;
        private const string DataFileName = "Data";
        private GameData _gameData;
        [Inspectable("当前关卡Id，从0开始")]private int _currentLevelID;
        [Inspectable("当前观看数")]private float _currentViewNum;
        [Inspectable("当前关注数")]private float _currentFollowNum;
        [Inspectable("当前打赏数")]private float _currentRewardNum;
        [Inspectable("用于指定Video的索引")]private int _selectVideoIndex;
        [Inspectable("用于指定AudienceReplyInterface的背景")]private float _publishCoefficient;

        public int CurrentLevelID => _currentLevelID;
        public LevelData CurrentLevelData => GetLevelData(CurrentLevelID);
        
        public float PublishCoefficient => _publishCoefficient;


        public int SelectVideoIndex
        {
            get => _selectVideoIndex;
            set
            {
                PFCLog.Info("DataManager", $"SelectVideoIndex:{value}");
                _selectVideoIndex = value;
            }
        }

        public RevenueData CurrentRevenueData => new()
        {
            followNum = _currentFollowNum,
            viewNum = _currentViewNum,
            rewardNum = _currentRewardNum
        };

        private void OnEnable()
        {
            EventSystem.AddEventListener("PassLevel", SaveData);
        }
        
        private void OnDisable()
        {
            EventSystem.RemoveEventListener("PassLevel", SaveData);
            SaveData();
        }

        private void Start()
        {
            LoadData();
        }



        public LevelData GetLevelData(int level)
        {
            return levelData[level];
        }

        public void ChangeRevenue(RevenueData data)
        {
            _currentFollowNum += data.followNum;
            _currentViewNum += data.viewNum;
            _currentRewardNum += data.rewardNum;
        }

        public bool BeyondExpectedRevenue()
        {
            var expectedRevenues = CurrentLevelData.expectedRevenue;
            return expectedRevenues.Any(expectedRevenue => _currentFollowNum >= expectedRevenue.followNum 
                                                           && _currentViewNum >= expectedRevenue.viewNum 
                                                           && _currentRewardNum >= expectedRevenue.rewardNum);
        }
        
        private void LoadData()
        {
            _gameData = SaveSystem.Load<GameData>(DataFileName) ?? new GameData();
            _currentLevelID = _gameData.CurrentLevelID;
        }
        
        private void SaveData()
        {
            SaveSystem.Save(DataFileName,new GameData(_currentLevelID));
        }

        public void PassLevel()
        {
            _currentLevelID++;
            if (_currentLevelID >= LevelData.Count)
                _currentLevelID = 0;
        }

        public void ResetData()
        {
            // if(!BeyondExpectedRevenue())
            //     _currentLevelID = 0;
            _currentFollowNum = 0;
            _currentViewNum = 0;
            _currentRewardNum = 0;
            _publishCoefficient = 0;
        }
        
        public void ResetCoefficient()
        {
            _publishCoefficient = 0;
        }
        
        public int GetPublishIndex()
        {
            return _publishCoefficient switch
            {
                < 0.33f => 0,
                < 0.66f => 1,
                _ => 2
            };
        }
        
        public void ChangePublishCoefficient(float value)
        {
            _publishCoefficient += value;
            if (_publishCoefficient < 0)
                _publishCoefficient = 0;
            if (_publishCoefficient > 1)
                _publishCoefficient = 1;
        }

        public void ResetLevel()
        {
            _currentLevelID = 0;
        }
    }
}