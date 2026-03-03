using Member.Core.EventBus;
using Member.kJH.Code.Sounds;
using UnityEngine;

namespace Member.kJH.Code.Event
{
    public struct PlaySFXEvent : IEvent
    {
        public Vector3 Position;
        public SoundSO SoundClip;

        public static PlaySFXEvent Initializer(Vector3 position, SoundSO soundClip)
        {
            return new PlaySFXEvent
            {
                Position = position,
                SoundClip = soundClip
            };
        }
    }
}