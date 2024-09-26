// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class Comment : MonoBehaviour
    {
        [SerializeField]private Text userName;
        [SerializeField]private Text commentText;
        [SerializeField]private Image userHead;
        
        public void ShowComment(CommentInfo info)
        {
            userName.text = info.UserName;
            commentText.text = info.Comment;
            userHead.sprite = info.UserHead;
        }
    }
}