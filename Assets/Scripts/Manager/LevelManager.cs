// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using Data;
using PurpleFlowerCore.Utility;
using UnityEngine;

namespace Manager
{
    public class LevelManager : DdolSingletonMono<LevelManager>
    {
        private int _currentLevelID = 0;
        public int CurrentLevelID => _currentLevelID;
        
        public LevelData CurrentLevelData => DataManager.Instance.GetLevelData(_currentLevelID);
        
    }
}