using Member.Core.EventBus;

namespace Member.kJH.Code.Event
{
    public struct StopLongSFXEvent : IEvent
    {
        public int IdxNumber;

        public StopLongSFXEvent Initializer(int idxNumber)
        {

            return new StopLongSFXEvent
            {
                IdxNumber = idxNumber
            };
        }
    }
}