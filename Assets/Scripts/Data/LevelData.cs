// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Data/LevelData")]
    public class LevelData : ScriptableObject
    {
        public int id;
        public List<string> messageOptions = new();
        public List<Animation> animations = new();
        public List<string> tags = new();
        public List<string> comments = new();
    }
}