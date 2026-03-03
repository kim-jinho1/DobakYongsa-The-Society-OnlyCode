using System.Collections.Generic;
using UnityEngine;

namespace Member.kJH.Code.UI
{
    public class HoveringUI : MonoBehaviour
    {
        [SerializeField] private List<GameObject> panels = new List<GameObject>();

        private void Awake()
        {
            foreach (var panel in panels)
            {
                if (panel.GetComponent<HoverScaleUI>() == null)
                {
                    panel.AddComponent<HoverScaleUI>();
                }
            }
        }
    }
}