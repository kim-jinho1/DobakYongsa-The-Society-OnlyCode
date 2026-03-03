using System;
using Member.Core.EventBus;
using Member.kJH.Code.Event;
using UnityEngine;

namespace Member.kJH.Code.Sounds.Sound
{
    public class BGMSound : MonoBehaviour
    {
        [SerializeField] private SoundSO sound;

        private void Start()
        {
            SoundPlay();
        }

        private void SoundPlay()
        {
            var bgmEvt = PlayBGMEvent.Initializer(sound);
            Bus<PlayBGMEvent>.Raise(Owner.AI1, bgmEvt);
        }   
    }
}