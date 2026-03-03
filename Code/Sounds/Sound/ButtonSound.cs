using Member.Core.EventBus;
using Member.kJH.Code.Event;
using UnityEngine;

namespace Member.kJH.Code.Sounds.Sound
{
    public class ButtonSound : MonoBehaviour
    {
        [SerializeField] private SoundSO sound1;
        [SerializeField] private SoundSO sound2;
        
        public void ButtonSoundPlay()
        {
            var sfxEvent = PlaySFXEvent.Initializer(transform.position, sound1);
            Bus<PlaySFXEvent>.Raise(Owner.AI1, sfxEvent);
        }

        public void StartButtonSound()
        {
            var sfxEvent = PlaySFXEvent.Initializer(transform.position, sound2);
            Bus<PlaySFXEvent>.Raise(Owner.AI1, sfxEvent);
        }
    }
}