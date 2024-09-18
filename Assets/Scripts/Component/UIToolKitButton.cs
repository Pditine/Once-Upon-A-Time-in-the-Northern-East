// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System;
using System.Collections.Generic;
using Manager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Component
{
    public class UIToolKitButton : MonoBehaviour
    {
        [SerializeField]private List<string> buttonNames = new();
        [SerializeField]private List<UnityEvent> events = new();
        private readonly List<Button> _buttonBuffer = new();
        private VisualElement Root => GetComponent<UIDocument>().rootVisualElement;

        private void OnEnable()
        {
            if(buttonNames.Count != events.Count) throw new Exception("ButtonNames and Events count must be the same");
            for (var i = 0; i < buttonNames.Count; i++)
            {
                var index = i;
                var button = Root.Q<Button>(buttonNames[i]);
                _buttonBuffer.Add(button);
                button.RegisterCallback<ClickEvent>(evt => events[index].Invoke());
                button.RegisterCallback<ClickEvent>(evt => AudioManager.Instance.PlayEffect("Button"));
            }
        }

        private void OnDisable()
        {
            foreach (var button in _buttonBuffer)
            {
                button.Clear();
            }
        }
    }
    
}