 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class EvaluationUI : MonoBehaviour
{
    public float loadingTime;
    public float currentLoadingTime;
    public bool loading = false;

    public int nextLevel;

    private UIDocument _document;

    private Button _button;
    private List<Button> _menuButtons = new List<Button>();

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _document = GetComponent<UIDocument>();

        _button = _document.rootVisualElement.Q("Continue") as Button;
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
        currentLoadingTime = loadingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(loading){
            currentLoadingTime -= Time.deltaTime;
        }

        if(currentLoadingTime <=0){
            SceneManager.LoadScene(nextLevel);
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
        Debug.Log("Pressed Continue");
    }

    private void OnAllButtonsClick(ClickEvent evt)
    {
        if(!_audioSource.isPlaying){
            _audioSource.Play();
        }
    }
}
