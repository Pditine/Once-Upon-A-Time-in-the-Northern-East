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

namespace Manager
{
    public class DataManager : DdolSingletonMono<DataManager>
    {
        [SerializeField]private List<LevelData> levels = new();
        private const string DataFileName = "Data";
        public GameData GameData { get; private set; }

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

        private void LoadData()
        {
            GameData = SaveSystem.Load<GameData>(DataFileName) ?? new GameData();
        }
        
        private void SaveData()
        {
            SaveSystem.Save( DataFileName,GameData);
        }

    }
}