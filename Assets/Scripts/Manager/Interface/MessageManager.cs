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
        }

        private void SetMessageInfo()
        {
            otherName.text = CurrentLevelMessageData.otherName;
        }

        private void StartMessage1()
        {
            DelayUtility.Delay(4, () =>
            {
                StartCoroutine(DoStartMessage1());
            });
        }
        
        private IEnumerator DoStartMessage1()
        {
            foreach (var message in CurrentLevelMessageData.messages1)
            {
                Instantiate(messagePrototype, content).ShowMessage(message);
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
                Instantiate(messagePrototype, content).ShowMessage(message);
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
        
        public void CreateMessageByOption(Text text)
        {
            Instantiate(messagePrototype, content).ShowMessage(new MessageInfo()
            {
                isLeft = false,
                messageText = text.text,
                messageImage = null
            });
        }

        public void SelectOption(int index)
        {
            if (_hasSelectedOption) return;
            _hasSelectedOption = true;
            DataManager.Instance.SelectVideoIndex = index;

        }
    }
}