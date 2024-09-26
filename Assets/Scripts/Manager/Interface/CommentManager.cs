// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using GamePlay;
using PurpleFlowerCore.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.Interface
{
    public class CommentManager : MonoBehaviour
    {
        [SerializeField] private Text commentNum;
        [SerializeField] private List<Comment> comments = new();
        private List<CommentInfo> CurrentLevelComments => DataManager.Instance.CurrentLevelData.commentData;
        private void OnEnable()
        {
            Init();
        }

        private void Init()
        {
            InitCommentNum();
            InitComments();
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
        }

        private void InitCommentNum()
        {
            var currentRevenueData = DataManager.Instance.CurrentRevenueData;
            int num = (int)(currentRevenueData.followNum + currentRevenueData.rewardNum + currentRevenueData.viewNum)/3;
            commentNum.text = $"{num}条评论";
        }
        
        private void NextPage()
        {
            InterfaceManager.Instance.NextPage();
        }
    }
}