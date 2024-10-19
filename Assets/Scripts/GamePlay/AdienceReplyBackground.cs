using System.Collections.Generic;
using System.Linq;
using Manager;
using PurpleFlowerCore.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class AudienceReplyBackground : MonoBehaviour
    {
        [SerializeField] private Text commentNum;
        [SerializeField] private List<Comment> comments = new();
        [SerializeField] private Image background;
        [SerializeField] private Transform commentRoot;
        [SerializeField] private List<Transform> commentPoints = new();
        [SerializeField] private List<Sprite> backgroundSprites = new();
        [SerializeField] private Image whitePanel;
        private List<CommentInfo> CurrentLevelComments => DataManager.Instance.CurrentLevelData.commentData;
        private int PublishIndex => DataManager.Instance.GetPublishIndex();
        
        public void Init()
        {
            transform.localScale = new Vector3(1,1,1);
            InitCommentNum();
            InitComments();
            InitBackground();
        }
        private void InitCommentNum()
        {
            var currentRevenueData = DataManager.Instance.CurrentRevenueData;
            int num = (int)(currentRevenueData.followNum + currentRevenueData.rewardNum + currentRevenueData.viewNum)*1000/3 + Random.Range(0,1000);
            commentNum.text = $"{num}条评论";
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

        private void InitBackground()
        {
            background.sprite = backgroundSprites[PublishIndex];
            whitePanel.enabled = false;
        }
        
        public void ShowWhitePanel()
        {
            FadeUtility.FadeInAndStay(whitePanel, 50);
            ScaleUtility.MoveTowards(new Vector3(1.4f, 1.4f, 1.4f), transform, 30f);
            
        }
    }
}