// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System;
using System.Collections.Generic;
using Data;
using PurpleFlowerCore;
using PurpleFlowerCore.Utility;
using UnityEngine;
using UnityEngine.Serialization;

namespace Manager
{
    public class DataManager : DdolSingletonMono<DataManager>
    {
        [SerializeField]private List<LevelData> levelData = new();
        public List<LevelData> LevelData => levelData;
        private const string DataFileName = "Data";

        private GameData _gameData;
        public GameData GameData
        {
            get
            {
                if(GameData is null) LoadData();
                return _gameData;
            }
            set => throw new NotImplementedException();
        }

        private void OnEnable()
        {
            EventSystem.AddEventListener("LevelOver", SaveData);
        }

        private void OnDisable()
        {
            EventSystem.RemoveEventListener("LevelOver", SaveData);
        }

        private void Start()
        {
            LoadData();
        }
        
        public LevelData GetLevelData(int level)
        {
            return levelData[level];
        }

        private void LoadData()
        {
            _gameData = SaveSystem.Load<GameData>(DataFileName) ?? new GameData();
        }
        
        private void SaveData()
        {
            SaveSystem.Save( DataFileName,GameData);
        }

    }
}