using Member.Core.EventBus;
using Member.kJH.Code.Sounds;

namespace Member.kJH.Code.Event
{
    public struct PlayBGMEvent : IEvent
    {
        public SoundSO BGMClip;

        public static PlayBGMEvent Initializer(SoundSO bgmClip)
        {
            return new PlayBGMEvent
            {
                BGMClip = bgmClip
            };
        }
    }
}