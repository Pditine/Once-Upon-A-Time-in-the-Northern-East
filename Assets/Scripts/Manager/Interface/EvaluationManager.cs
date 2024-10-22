// //-------------------------------------------------
// //copyright@ LiJianhao
// //Licensed under the MIT License
// //-------------------------------------------------

using System.Globalization;
using PurpleFlowerCore;
using PurpleFlowerCore.Utility;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Manager.Interface
{
    public class EvaluationManager : MonoBehaviour
    {
        [SerializeField] private CanvasGroup thisInterface;
        [SerializeField] private Text viewNum;
        [SerializeField] private Text followNum;
        [SerializeField] private Text rewardNum;
        [SerializeField] private float intervalTime;
        [SerializeField] private Image passBtnImage;
        [SerializeField] private Sprite winSprite;
        [SerializeField] private Sprite loseSprite;
        [SerializeField] private GameObject SuccessCG;
        [SerializeField] private GameObject FailCG;
        [SerializeField] private AudioClip winClip;
        [SerializeField] private AudioClip loseClip;
        private RevenueData CurrentRevenueData => DataManager.Instance.CurrentRevenueData;

        private void OnEnable()
        {
            Init();
        }

        private void Init()
        {
            thisInterface.alpha = 1;
            SuccessCG.SetActive(false);
            FailCG.SetActive(false);
            InitData();
            //InitContinue();
            StartShow();
        }
        
        private void InitData()
        {
            viewNum.text = $"view:{CurrentRevenueData.viewNum.ToString(CultureInfo.InvariantCulture)}k";
            followNum.text = $"follow:{CurrentRevenueData.followNum.ToString(CultureInfo.InvariantCulture)}k";
            rewardNum.text = $"reward:{CurrentRevenueData.rewardNum.ToString(CultureInfo.InvariantCulture)}k";
            passBtnImage.sprite = DataManager.Instance.BeyondExpectedRevenue()?winSprite:loseSprite; 
            passBtnImage.SetNativeSize();
            viewNum.enabled = false;
            followNum.enabled = false;
            rewardNum.enabled = false;
            passBtnImage.enabled = false;
        }
        
        
        public void Continue()
        {
            if(DataManager.Instance.BeyondExpectedRevenue())
            {
                Win();
                EventSystem.EventTrigger("PassLevel");
            }
            else
                Lose();
        }

        public void StartShow()
        {
            StartCoroutine(DoStartShow());
        }

        public IEnumerator DoStartShow()
        {
            yield return new WaitForSeconds(intervalTime);
            FadeUtility.FadeInAndStay(viewNum, 80);
            yield return new WaitForSeconds(intervalTime);
            FadeUtility.FadeInAndStay(followNum, 80);
            yield return new WaitForSeconds(intervalTime);
            FadeUtility.FadeInAndStay(rewardNum, 80);
            yield return new WaitForSeconds(intervalTime);
            FadeUtility.FadeInAndStay(passBtnImage, 80);
        }
        
        private void Win()
        {
            DataManager.Instance.PassLevel();
            //先ID++,再判断
            if(DataManager.Instance.CurrentLevelID == DataManager.Instance.LevelData.Count - 1)
                ShowCG(true);
            else
                InterfaceManager.Instance.NextPage();
        }
        
        private void Lose()
        {
            DataManager.Instance.ResetLevel();
            //InterfaceManager.Instance.NextPage();
            ShowCG(false);
        }

        private void ShowCG(bool isWin)
        {
            var cdObj = isWin ? SuccessCG : FailCG;
            var clip = isWin ? winClip : loseClip;
            AudioSystem.PlayEffect(clip,transform);
            cdObj.SetActive(true);
            FadeUtility.FadeOut(thisInterface, 100);
            DelayUtility.Delay(clip.length, () =>
            {
                InterfaceManager.Instance.NextPage();
            });
        }
    }
}