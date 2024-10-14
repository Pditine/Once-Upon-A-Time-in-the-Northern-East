// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System.Collections.Generic;
using PurpleFlowerCore;
using PurpleFlowerCore.Utility;
using UnityEngine;

namespace Manager.Interface
{
    public class RecordManager : MonoBehaviour
    {
        [SerializeField] private Transform sceneRoot;
        // [SerializeField] private float videoTime = 5;
        private RecordInfo CurrentRecordInfo => DataManager.Instance.CurrentLevelData.recordData[DataManager.Instance.SelectVideoIndex];
        private GameObject _video;
        

        private void OnEnable()
        {
            _video = Instantiate(CurrentRecordInfo.video, sceneRoot.position, Quaternion.identity, sceneRoot);
            PFCLog.Info("record",$"record start:{CurrentRecordInfo.video.name}");
            AudioSystem.PlayEffect(CurrentRecordInfo.audio,transform);
            DelayUtility.Delay(CurrentRecordInfo.audio.length,RecordOver);
        }
        
        private void RecordOver()
        {
            Destroy(_video,1.2f);
            InterfaceManager.Instance.NextPage();
        }
    }
}