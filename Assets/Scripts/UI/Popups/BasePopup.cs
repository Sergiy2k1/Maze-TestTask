using DG.Tweening;
using UnityEngine;

namespace UI.Popups
{
    public class BasePopup : MonoBehaviour
    {
        [SerializeField] private Transform content;
        [SerializeField] private CanvasGroup canvasGroup;

        [SerializeField] private float animationDuration = 0.5f;

        private void OnEnable() => 
            Initial();

        

        protected virtual void Initial()
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            content.gameObject.SetActive(false);
        }

        public virtual void ShowView()
        {
            content.gameObject.SetActive(true);
            
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            
            canvasGroup.DOFade(1f, animationDuration).SetEase(Ease.OutQuad).OnComplete(() =>
            {
                canvasGroup.alpha = 1f;
            });
        }

        public virtual void HideView()
        {
            canvasGroup.DOFade(0f, animationDuration).SetEase(Ease.InQuad).OnComplete(() =>
            {
                content.gameObject.SetActive(false);
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            });
        }
    }
}
