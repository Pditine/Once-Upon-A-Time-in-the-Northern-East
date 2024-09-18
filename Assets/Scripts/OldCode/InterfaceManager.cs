using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    public GameObject publishInteface;
    public GameObject commentInterface;
    public GameObject levelEndInterface;

    public bool published;
    public bool commented;
    // public bool evaluated;

    public bool commenting;
    public bool evaluating;

    public float viewingTime;
    public float currentVewingTime;
    private bool loading;
    

    private UIDocument _document;

    private Button _button;
    private List<Button> _menuButtons = new List<Button>();

    // Start is called before the first frame update
    void Start()
    {
        commentInterface.SetActive(false);
        levelEndInterface.SetActive(false);

        currentVewingTime = viewingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(published){
            commenting = true;
            commentInterface.SetActive(true);
            publishInteface.SetActive(false);
        }

        if(commenting){
            currentVewingTime -= Time.deltaTime;
            
            if(currentVewingTime <= 0){
                commented = true;
            }
        }

        if(commented){
            evaluating = true;
            levelEndInterface.SetActive(true);
            commentInterface.SetActive(false);
        }

        // if(loading){
        //     currentLoadingTime -= Time.deltaTime;
        // }

        // if(currentLoadingTime <= 0){
        //     SceneManager.LoadScene(3);
        // }
    }

}
