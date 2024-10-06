// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using UnityEngine;

namespace Data
{
    public class GameData
    {
        [SerializeField]public int CurrentLevelID;
        
        public GameData()
        {
            CurrentLevelID = 0;
        }
        
        public GameData(int currentLevelID)
        {
            CurrentLevelID = currentLevelID;
        }
    }
}