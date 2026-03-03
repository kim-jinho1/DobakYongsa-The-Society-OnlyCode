using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

namespace Member.kJH.Code.Timeline
{
    public class TimelineUIHandler : MonoBehaviour
    {
        [SerializeField] private PlayableDirector director;
        [SerializeField] private GameObject targetUI;
        [SerializeField] private Button skipButton;

        private void Awake()
        {
            director.stopped += OnTimelineStopped;

            if (skipButton != null)
                skipButton.onClick.AddListener(SkipTimeline);
        }

        private void OnTimelineStopped(PlayableDirector obj)
        {
            if (targetUI != null)
                targetUI.SetActive(false);
        }

        private void SkipTimeline()
        {
            director.Stop();
        }
    }
}