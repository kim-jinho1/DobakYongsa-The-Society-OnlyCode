using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Member.kJH.Code.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private RectTransform mainButtonPanel;
        [SerializeField] private RectTransform settingPanel;
        [SerializeField] private RectTransform tutorialPanel;
        
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;

        private int _idx = 1;

        private Vector2 _mainTarget;
        private Vector2 _tutorialTarget;
        private Vector2 _settingTarget;

        private void Awake()
        {
            leftButton.onClick.AddListener(LeftButtonClick);
            rightButton.onClick.AddListener(RightButtonClick);

            _mainTarget = mainButtonPanel.anchoredPosition;
            _tutorialTarget = tutorialPanel.anchoredPosition;
            _settingTarget = settingPanel.anchoredPosition;
        }

        private void OnDestroy()
        {
            leftButton.onClick.RemoveListener(LeftButtonClick);
            rightButton.onClick.RemoveListener(RightButtonClick);
            DOTween.Kill(mainButtonPanel);
            DOTween.Kill(tutorialPanel);
            DOTween.Kill(settingPanel);
        }

        private void LeftButtonClick()
        {
            if (_idx == 0)
                return;
            _idx--;
            MovePanels(-1200f);
        }

        private void RightButtonClick()
        {
            if (_idx == 2)
                return;
            _idx++;
            MovePanels(1200f);
        }

        private void MovePanels(float offsetX)
        {
            _mainTarget += new Vector2(offsetX, 0);
            _tutorialTarget += new Vector2(offsetX, 0);
            _settingTarget += new Vector2(offsetX, 0);
            
            mainButtonPanel.DOAnchorPos(_mainTarget, 0.4f).SetEase(Ease.OutCubic).SetId(mainButtonPanel);
            tutorialPanel.DOAnchorPos(_tutorialTarget, 0.4f).SetEase(Ease.OutCubic).SetId(tutorialPanel);
            settingPanel.DOAnchorPos(_settingTarget, 0.4f).SetEase(Ease.OutCubic).SetId(settingPanel);
        }
    }
}
