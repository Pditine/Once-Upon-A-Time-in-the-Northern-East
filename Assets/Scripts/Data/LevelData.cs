// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]public struct RevenueData
{
    public float followNum;
    public float viewNum;
    public float rewardNum;
}

namespace Data
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Data/LevelData")]
    public class LevelData : ScriptableObject
    {
        public int id;
        public string levelName;
        public List<string> messageOptions = new();
        public List<UnityEvent> messageEvents = new();
        public List<string> titles = new();
        public List<UnityEvent> titleEvents = new();
        public List<string> tags = new();
        public List<UnityEvent> tagEvents = new();
        public List<string> comments = new();
        public List<RevenueData> expectedRevenue = new();
        public List<GameObject> videos = new();
    }
}