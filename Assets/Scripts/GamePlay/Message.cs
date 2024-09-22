// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System;
using Manager;
using PurpleFlowerCore;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class Message : MonoBehaviour
    {
        [SerializeField] private Image leftHead;
        [SerializeField] private Image rightHead;
        [SerializeField] private Text messageText;
        [SerializeField] private Image messageImage;
        
        public void ShowMessage(MessageInfo info)
        {
            PFCLog.Info("Message",$"show message:{info.messageText}");
            var currentHead = info.isLeft ? leftHead : rightHead;
            currentHead.sprite = info.isLeft ? LevelManager.Instance.CurrentLevelData.messageData.leftHead : LevelManager.Instance.CurrentLevelData.messageData.rightHead;
            currentHead.gameObject.SetActive(true);
            messageText.text = info.messageText;
            messageImage.sprite = info.messageImage;
            messageText.transform.parent.gameObject.SetActive(!string.IsNullOrEmpty(info.messageText));
            messageImage.gameObject.SetActive(info.messageImage != null);
            if(info.messageImage != null)
            {
                messageImage.SetNativeSize();
                var messageRect = GetComponent<RectTransform>();
                messageRect.sizeDelta = new Vector2(messageRect.sizeDelta.x, messageImage.rectTransform.sizeDelta.y + 20);
            }
        }
    }
}