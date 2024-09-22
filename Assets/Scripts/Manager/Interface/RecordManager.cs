// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using PurpleFlowerCore;
using PurpleFlowerCore.Utility;
using UnityEngine;

namespace Manager.Interface
{
    public class RecordManager : MonoBehaviour
    {
        [SerializeField] private Transform sceneRoot;

        private void OnEnable()
        {
            var levelData = LevelManager.Instance.CurrentLevelData;
            Instantiate(levelData.videos[0], sceneRoot.position, Quaternion.identity, sceneRoot);
            PFCLog.Info("record",$"record start:{levelData.videos[0].name}");
            DelayUtility.Delay(5,RecordOver);
        }
        
        private void RecordOver()
        {
            InterfaceManager.Instance.NextPage();
        }
    }
}