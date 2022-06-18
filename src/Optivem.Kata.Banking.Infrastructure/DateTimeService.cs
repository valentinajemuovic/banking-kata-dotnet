using Optivem.Kata.Banking.Core.Domain.Time;

namespace Optivem.Kata.Banking.Infrastructure
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}