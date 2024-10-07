// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay;
using PurpleFlowerCore.Utility;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Manager.Interface
{
    public class MessageManager : MonoBehaviour
    {
        [SerializeField] private RectTransform content;
        [SerializeField] private Text otherName;
        [SerializeField] private Message messagePrototype;
        [SerializeField] private float messageWaitTime = 0.5f;
        [SerializeField] private List<Option> options;
        private List<Message> _currentMessages = new();
        private bool _hasSelectedOption = false;

        private MessageData CurrentLevelMessageData => DataManager.Instance.CurrentLevelData.messageData;
        
        private void OnEnable()
        {
            Init();
            StartMessage1();
            SetMessageInfo();
        }

        private void Init()
        {
            _hasSelectedOption = false;
            foreach (var currentMessage in _currentMessages)
            {
                Destroy(currentMessage.gameObject);
            }
            _currentMessages.Clear();
        }

        private void SetMessageInfo()
        {
            otherName.text = CurrentLevelMessageData.otherName;
        }

        private void StartMessage1()
        {
            foreach (var option in options)
            {
                option.HideOption();
            }
            DelayUtility.Delay(4, () =>
            {
                StartCoroutine(DoStartMessage1());
            });
        }
        
        private IEnumerator DoStartMessage1()
        {
            foreach (var message in CurrentLevelMessageData.messages1)
            {
                CreateMessageByInfo(message);
                yield return new WaitForSeconds(messageWaitTime);
            }
            for(int i = 0; i < CurrentLevelMessageData.messageOptions.Count; i++)
            {
                var option = options[i];
                option.ShowOption(CurrentLevelMessageData.messageOptions[i]);
                option.AddListener(StartMessage2);
            }
        }

        private void StartMessage2()
        {
            StartCoroutine(DoStartMessage2());
        }

        private IEnumerator DoStartMessage2()
        {
            foreach (var option in options)
            {
                option.HideOption();
            }
            yield return new WaitForSeconds(2);
            foreach (var message in CurrentLevelMessageData.messages2)
            {
                CreateMessageByInfo(message);
                yield return new WaitForSeconds(messageWaitTime);
            }
            UnityEvent nextInterface = new UnityEvent();
            nextInterface.AddListener(() =>
            {
                InterfaceManager.Instance.NextPage();
            });
            options[0].ShowOption(new OptionInfo()
            {
                optionText = "Let's GOOO!",
                optionEvent = nextInterface
            });
        }

        private void CreateMessageByInfo(MessageInfo info)
        {
            var message = Instantiate(messagePrototype, content);
            message.ShowMessage(info);
            _currentMessages.Add(message);
        }
        
        public void CreateMessageByOption(Text text)
        {
            var message = Instantiate(messagePrototype, content);
            message.ShowMessage(new MessageInfo()
            {
                isLeft = false,
                messageText = text.text,
                messageImage = null
            });
            _currentMessages.Add(message);
        }

        public void SelectOption(int index)
        {
            if (_hasSelectedOption) return;
            _hasSelectedOption = true;
            DataManager.Instance.SelectVideoIndex = index;

        }
    }
}