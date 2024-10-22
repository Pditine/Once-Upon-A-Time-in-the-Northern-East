// //-------------------------------------------------
//  //copyright@ LiJianhao
//  //Licensed under the MIT License
//  //-------------------------------------------------
using System.Collections.Generic;
using Manager;
using PurpleFlowerCore.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class Device : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Sprite[] sprites;
        [SerializeField] private List<Transform> points;
        [SerializeField] private float waitTime = 3f;
        
        private int PublishIndex => DataManager.Instance.GetPublishIndex();
        
        public void Init()
        {
            transform.position = points[PublishIndex].position;
            image.sprite = sprites[PublishIndex];
            image.SetNativeSize();
            image.color = new Color(1,1,1,0);
            image.enabled = false;
            DelayUtility.Delay(waitTime, () =>
            {
                FadeUtility.FadeInAndStay(image, 80);
            });
        }

        public void Disappear()
        {
            FadeUtility.FadeOut(image, 80);
        }
    }
}