// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------
namespace Data
{
    public class GameData
    {
        public readonly int CurrentLevelID = 0;
        
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