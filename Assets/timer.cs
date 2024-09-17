using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class timer : MonoBehaviour
{
    [SerializeField]
    float timer01;
    [SerializeField]
    float timerrun, timerback;

    [SerializeField]
    AutoMoveAndRotate auto01;
    // Start is called before the first frame update
    void Start()
    {
       auto01 = GetComponentInParent<AutoMoveAndRotate>();
       auto01.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer01 += Time.deltaTime;
        if (timer01 > timerrun )
        {
          auto01.enabled = true;    
        }
        if(timer01 > timerback )
        {
           auto01.enabled = false;
        }
        //else { auto01.enabled = false; }
    }
}
