using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace Member.kJH.Code.UI
{
    public class HoverScaleUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private float scaleUpSize = 1.1f;
        [SerializeField] private float duration = 0.2f;

        private Vector3 _originalScale;
        private Tween _tween;

        private void Awake()
        {
            _originalScale = transform.localScale;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _tween?.Kill();
            _tween = transform.DOScale(_originalScale * scaleUpSize, duration)
                .SetEase(Ease.OutBack);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _tween?.Kill();
            _tween = transform.DOScale(_originalScale, duration)
                .SetEase(Ease.OutBack);
        }
    }
}