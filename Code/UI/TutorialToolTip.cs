using UnityEngine;
using UnityEngine.UI;

namespace Member.kJH.Code.UI
{
    public class TutorialToolTip : MonoBehaviour
    {
        [SerializeField] private Text text;

        public void ShowText(string tooltipText)
        {
            text.text = tooltipText;
        }
    }
}