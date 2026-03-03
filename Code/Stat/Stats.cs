using System;
using System.Collections.Generic;
using Member.kJH.Code.UI;
using UnityEngine;

namespace Member.kJH.Code.Stat
{
    public class Stats : MonoBehaviour
    {
        [SerializeField] private List<BaseStatData> statDataList;
        [SerializeField] private StatsUI[] statUI;

        private readonly Dictionary<StatType, BaseStat> _stats = new();
        private readonly Dictionary<StatType, StatsUI> _statUIs = new();

        private void Awake()
        {
            foreach (var data in statDataList)
            {
                BaseStat stat = new BaseStat(data);
                _stats[data.stat] = stat;
            }
        }

        private void Start()
        {
            int idx = 0;
            foreach (var baseStat in _stats)
            {
                statUI[idx].EnableFor(baseStat.Value);
                _statUIs[baseStat.Value.Stat] = statUI[idx];
                idx++;
            }
        }

        public void UpdateUI(StatType statType)
        {
            _statUIs[statType].Update();
        }

        public BaseStat GetStat(StatType statType)
        {
            return _stats.GetValueOrDefault(statType);  
        }
    }
}