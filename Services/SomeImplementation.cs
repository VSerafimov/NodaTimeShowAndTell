using NodatimeDemo.Interfaces;
using NodaTime;

namespace NodatimeDemo.Services
{
    public class SomeImplementation : ISomeImplementation
    {
        private readonly IClock _clock;
        private readonly DateTimeZone _businessTimeZone = DateTimeZoneProviders.Tzdb["America/New_York"];

        public SomeImplementation(IClock clock)
        {
            _clock = clock;
        }
        public LocalDateTime GetNewYorkDateTime()
        {
            var today = _clock.Now.InZone(_businessTimeZone).Date;
            return today.AtMidnight();
        }
    }
}
