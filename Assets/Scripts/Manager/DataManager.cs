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
        private int _currentLevelID = 0;
        private float _currentViewNum;
        private float _currentFollowNum;
        private float _currentRewardNum;
        private int _selectVideoIndex;
        private GameData _gameData;

        public int CurrentLevelID => _currentLevelID;
        public LevelData CurrentLevelData => GetLevelData(CurrentLevelID);

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

        // private void OnEnable()
        // {
        //     EventSystem.AddEventListener("LevelOver", SaveData);
        // }
        //
        // private void OnDisable()
        // {
        //     EventSystem.RemoveEventListener("LevelOver", SaveData);
        // }

        private void Start()
        {
            LoadData();
        }

        private void OnDisable()
        {
            SaveData();
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
            _currentLevelID = 0;
            _currentFollowNum = 0;
            _currentViewNum = 0;
            _currentRewardNum = 0;
        }

    }
}