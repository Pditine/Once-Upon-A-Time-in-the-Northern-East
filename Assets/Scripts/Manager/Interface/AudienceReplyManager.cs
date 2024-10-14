// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using GamePlay;
using PurpleFlowerCore;
using PurpleFlowerCore.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.Interface
{
    public class AudienceReplyManager : MonoBehaviour
    {
        [SerializeField] private Text commentNum;
        [SerializeField] private List<Comment> comments = new();
        [SerializeField] private Image background;
        [SerializeField] private Transform commentRoot;
        [SerializeField] private List<Transform> commentPoints = new();
        [SerializeField] private List<Sprite> backgroundSprites = new();
        private List<CommentInfo> CurrentLevelComments => DataManager.Instance.CurrentLevelData.commentData;
        private int PublishIndex => DataManager.Instance.GetPublishIndex();
        private void OnEnable()
        {
            Init();
        }

        private void Init()
        {
            PFCLog.Info("AudienceReplyManager", $"PublishIndex:{PublishIndex}");
            InitCommentNum();
            InitComments();
            InitBackground();
            DelayUtility.Delay(6, NextPage);
        }

        private void InitComments()
        {
            var commentPool = CurrentLevelComments.ToList();
            foreach (var t in comments)
            {
                int num = Random.Range(0, commentPool.Count);
                t.ShowComment(commentPool[num]);
                commentPool.RemoveAt(num);
            }
            commentRoot.position = commentPoints[PublishIndex].position;
        }

        private void InitCommentNum()
        {
            var currentRevenueData = DataManager.Instance.CurrentRevenueData;
            int num = (int)(currentRevenueData.followNum + currentRevenueData.rewardNum + currentRevenueData.viewNum)*1000/3 + Random.Range(0,1000);
            commentNum.text = $"{num}条评论";
        }

        private void InitBackground()
        {
            background.sprite = backgroundSprites[PublishIndex];
        }
        
        private void NextPage()
        {
            InterfaceManager.Instance.NextPage();
        }
    }
}