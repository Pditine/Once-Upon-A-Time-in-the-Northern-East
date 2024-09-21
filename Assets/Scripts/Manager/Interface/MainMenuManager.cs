// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using UnityEngine;

namespace Manager.Interface
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField]private GameObject settingPanel;
        
        public void StartGame()
        {
            InterfaceManager.Instance.NextPage();
        }

        public void Resume()
        {
            InterfaceManager.Instance.NextPage();
        }

        public void Setting()
        {
            settingPanel.SetActive(!settingPanel.activeSelf);
        }
        
        public void Quit()
        {
            Application.Quit();
        }
    }
}