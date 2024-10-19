// //-------------------------------------------------
//  //copyright@ LiJianhao
//  //Licensed under the MIT License
//  //-------------------------------------------------

using PurpleFlowerCore.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Text text;
        private readonly Vector3 _originScale = new(0, 0, 0);
        private readonly Vector3 _targetScale = new(1,1,1);
        private bool _clicked = false;
        public bool Clicked => _clicked;
        public void Init(AudienceReplyItemData data)
        {
            image.sprite = data.sprite;
            image.SetNativeSize();
            text.text = data.text;
            image.transform.localScale = _originScale;
            text.transform.localScale = _originScale;
            image.enabled = true;
            text.enabled = false;
            _clicked = false;
        }

        public void Show()
        {
            ScaleUtility.Lerp(_targetScale, image.transform, 120f);
        }

        public void ShowText()
        {
            if (!ScaleUtility.Lerp(_originScale, image.transform, 120f, () => { image.enabled = false; }))
                return;
            text.enabled = true;
            _clicked = true;
            
            ScaleUtility.Lerp(_targetScale, text.transform, 120f);
        }
        
        public void Disappear()
        {
            ScaleUtility.Lerp(_originScale, text.transform, 120f,()=>{text.enabled = false;});
        }
        
    }
}