using Manager;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Component
{
    public class ButtonEffect_Audio : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]private string audioName = "Button";
        public void OnPointerClick(PointerEventData eventData)
        {
            AudioManager.Instance.PlayEffect(audioName);
        }
    }
}