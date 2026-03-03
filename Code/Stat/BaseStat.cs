using UnityEngine;

namespace Member.kJH.Code.Stat
{
    public class BaseStat : IModifierStat
    {
        public StatType Stat { get; private set; }
        public string StatName { get; private set; }
        public int CurrentValue { get; private set; }
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public Sprite StatIcon { get; private set; }

        public BaseStat(BaseStatData data)
        {
            Stat = data.stat;
            CurrentValue = data.currentValue;
            StatName = data.statName;
            StatIcon = data.statIcon;
            MinValue = data.minValue;
            MaxValue = data.maxValue;
        }

        public void PlusValue(int value) 
            => CurrentValue = Mathf.Clamp(CurrentValue + value, MinValue, MaxValue);

        public void MultiplyValue(int value)
            => CurrentValue = Mathf.Clamp(CurrentValue * value, MinValue, MaxValue);

        public void MinusValue(int value)
            => CurrentValue = Mathf.Clamp(CurrentValue - value, MinValue, MaxValue);

        public void SubtractValue(int value)
            => CurrentValue = Mathf.Clamp(CurrentValue - value, MinValue, MaxValue);

        public void PlusPerScentValue(int value)
            => CurrentValue = (int)(CurrentValue + CurrentValue * (value / 100.0));

        public void MinusPerScentValue(int value)
            => CurrentValue = (int)(CurrentValue - CurrentValue * (value / 100.0));
    }
}