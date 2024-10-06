// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System;
using System.Collections.Generic;
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
    public RevenueData revenueData;
}

[Serializable]
public struct TagInfo
{
    public string tag;
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

namespace Data
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Data/LevelData")]
    public class LevelData : ScriptableObject
    {
        public int id;
        public string levelName;
        public MessageData messageData;
        public PublishData publishData;
        public List<CommentInfo> commentData = new();
        public List<RevenueData> expectedRevenue = new();
        public List<RecordInfo> recordData = new();
    }
}