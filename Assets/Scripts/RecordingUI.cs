using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordingUI : MonoBehaviour
{
    public float recordingTime;
    public float currentRecordingTime;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        currentRecordingTime = recordingTime;
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        currentRecordingTime -= Time.deltaTime;

        if(currentRecordingTime <= 0){
            SceneManager.LoadScene(2);
        }
    }

    //可以补一个fade-in effect，但是我忘了
    //补一个切换icon的动画，这个我也不会
}
