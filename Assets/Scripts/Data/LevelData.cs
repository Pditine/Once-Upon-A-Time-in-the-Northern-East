// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System;
using System.Collections.Generic;
using Manager;
using PurpleFlowerCore.Utility;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[Serializable]public struct MessageInfo
{
    public bool isLeft;
    public string messageText;
    public Sprite messageImage;
}

/// <summary>
/// 格式: 播片(message1),玩家选择(messageOpentions),播片(message2),Let's go
/// 玩家选择的时候对方不能发消息
/// </summary>
[Serializable]
public struct MessageData
{
    public string otherName;
    public Sprite leftHead;
    public Sprite rightHead;
    public List<MessageInfo> messages1;
    public List<OptionInfo> messageOptions;
    public List<MessageInfo> messages2;
}

[Serializable]
public struct RevenueData
{
    public float followNum;
    public float viewNum;
    public float rewardNum;
}

[Serializable]
public struct OptionInfo
{
    public string optionText;
    public UnityEvent optionEvent;
}

[Serializable]
public struct TitleInfo
{
    public string title;
    public float publishCoefficient;
    public RevenueData revenueData;
}

[Serializable]
public struct TagInfo
{
    public string tag;
    public float publishCoefficient;
    public RevenueData revenueData;
}

[Serializable]
public struct PublishData
{
    public List<TitleInfo> titles;
    public List<TagInfo> tags;
}

[Serializable]
public struct CommentInfo
{
    public string UserName;
    public Sprite UserHead;
    public string Comment;
}

[Serializable]
public struct RecordInfo
{
    public GameObject video;
    public AudioClip audio;
}

[Serializable]
public struct AudienceReplyItemData
{
    public Sprite sprite;
    public string text;
}

[Serializable]
public struct AudienceReplyData
{
    public List<AudienceReplyItemData> background1Data;
    public List<AudienceReplyItemData> background2Data;
    public List<AudienceReplyItemData> background3Data;
    [TextArea]public string finalText;
    public List<AudienceReplyItemData> GetAudienceReplyItemData()
    {
        var publishIndex = DataManager.Instance.GetPublishIndex();
        return publishIndex switch
        {
            0 => background1Data,
            1 => background2Data,
            2 => background3Data,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

namespace Data
{
    [Configurable]
    [CreateAssetMenu(fileName = "LevelData", menuName = "Data/LevelData")]
    public class LevelData : ScriptableObject
    {
        public int id;
        public string levelName;
        public MessageData messageData;
        public PublishData publishData;
        public List<CommentInfo> commentData = new();
        public List<RevenueData> expectedRevenue = new();
        public AudienceReplyData audienceReplyData;
        public List<RecordInfo> recordData = new();
    }
}