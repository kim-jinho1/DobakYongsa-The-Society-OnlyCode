using System;
using DG.Tweening;
using UnityEngine;

namespace Member.kJH.Code.UI
{
    public class ShowUI : MonoBehaviour
    {
        
        [SerializeField] private RectTransform upMovePosition;
        [SerializeField] private RectTransform downMovePosition;
        private RectTransform _prevUI;

        private Tween _currentTween;
        
        public void Show(RectTransform ui)
        {
            if (_prevUI != null)
            {
                _prevUI.DOMoveY(downMovePosition.position.y, 0.5f);
            }
            
            _currentTween = ui.DOMoveY(upMovePosition.position.y, 0.5f);
            
            _prevUI = ui;
        }

        public void Hide(RectTransform ui)
        {
            _currentTween = ui.DOMoveY(downMovePosition.position.y, 0.5f);
            if (_prevUI == ui)
                _prevUI = null;
        }

        private void OnDestroy()
        {
            _currentTween?.Kill();
        }
    }
}