using Member.Core.EventBus;
using Member.kJH.Code.Sounds;
using UnityEngine;

namespace Member.kJH.Code.Event
{
    public struct PlayLongSFXEvent : IEvent
    {
        public Vector3 Position;
        public SoundSO SoundClip;
        public int IdxNumber;

        public static PlayLongSFXEvent Initializer(Vector3 position, SoundSO soundClip, int idxNumber)
        {
            return new PlayLongSFXEvent
            {
                Position = position,
                SoundClip = soundClip,
                IdxNumber = idxNumber
            };
        }
    }
}