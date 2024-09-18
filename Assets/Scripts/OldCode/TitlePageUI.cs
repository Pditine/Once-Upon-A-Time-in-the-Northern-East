 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

 [Obsolete]
public class TitlePageUI : MonoBehaviour
{
    public float loadingTime;
    bool loading = false;

    private UIDocument _document;

    private Button _button;
    private List<Button> _menuButtons = new List<Button>();

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _document = GetComponent<UIDocument>();

        _button = _document.rootVisualElement.Q("Start") as Button;
        _button.RegisterCallback<ClickEvent>(OnPlayGameClick);

        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        
        for(int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(loading){
            loadingTime -= Time.deltaTime;
        }

        if(loadingTime <=0){
            SceneManager.LoadScene(1);
        }
    }

    private void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(OnPlayGameClick);

        for(int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        //这里需要一个根据不同名称的按钮激活不同功能的function，但是我不会写
        //怎么退出，怎么resume，怎么调用设置面板
        loading = true;
        //Debug.Log("Pressed Start");
    }

    private void OnAllButtonsClick(ClickEvent evt)
    {
        if(!_audioSource.isPlaying){
            _audioSource.Play();
        }
    }
}