using UnityEngine;

namespace Member.kJH.Code.Stat
{
    [CreateAssetMenu(fileName = "BaseStatData", menuName = "SO/BaseStatData", order = 0)]
    public class BaseStatData : ScriptableObject
    {
        public StatType stat;
        public string statName;
        public int currentValue;
        public int minValue;
        public int maxValue;
        public Sprite statIcon;
    }
}