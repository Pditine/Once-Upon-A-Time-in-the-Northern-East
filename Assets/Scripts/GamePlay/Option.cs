// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using PurpleFlowerCore;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GamePlay
{
    public class Option : MonoBehaviour
    {
        [SerializeField]private Text optionText;
        private Button TheButton => GetComponent<Button>();
        private OptionInfo _info;
        private UnityAction _action;
        public void ShowOption(OptionInfo info)
        {
            PFCLog.Info("Option",$"show option:{info.optionText}");
            HideOption();
            _info = info;
            gameObject.SetActive(true);
            optionText.text = _info.optionText;
            _action = _info.optionEvent.Invoke;
            if(_action != null)
                TheButton.onClick.AddListener(_action);
        }
        
        public void AddListener(UnityAction action)
        {
            TheButton.onClick.AddListener(action);
        }
        
        public void HideOption()
        {
            if(_action != null)
                TheButton.onClick.RemoveListener(_action);
            gameObject.SetActive(false);
        }
        
    }
}