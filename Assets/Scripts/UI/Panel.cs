using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class Panel : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        public void Show(float duration = 0.5f)
        {
            _canvasGroup.DOFade(1f, duration);
            _canvasGroup.blocksRaycasts = true;
        }

        public void Hide(float duration = 0.5f)
        {
            _canvasGroup.DOFade(0f, duration);
            _canvasGroup.blocksRaycasts = false;
        }
        
    }
}