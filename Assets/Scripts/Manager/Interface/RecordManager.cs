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
        [SerializeField] private float videoTime = 5;
        private GameObject _video;
        

        private void OnEnable()
        {
            var levelData = DataManager.Instance.CurrentLevelData;
            var index = DataManager.Instance.SelectVideoIndex;
            _video = Instantiate(levelData.videos[index], sceneRoot.position, Quaternion.identity, sceneRoot);
            PFCLog.Info("record",$"record start:{levelData.videos[index].name}");
            DelayUtility.Delay(videoTime,RecordOver);
        }
        
        private void RecordOver()
        {
            Destroy(_video,1.2f);
            InterfaceManager.Instance.NextPage();
        }
    }
}