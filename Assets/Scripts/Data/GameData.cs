// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using UnityEngine;

namespace Data
{
    public class GameData
    {
        public int CurrentLevelID;
        public float CurrentViewNum;
        public float CurrentFollowNum;
        public float CurrentRewardNum;        
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