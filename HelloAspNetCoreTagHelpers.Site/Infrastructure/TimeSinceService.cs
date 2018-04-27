using System;

namespace HelloAspNetCoreTagHelpers.Site.Infrastructure
{
    public class TimeSinceService : ITimeSinceService
    {
        public string TimeSince(DateTime from)
        {
            // based on algorithm provided by https://stackoverflow.com/questions/3383464/is-there-a-smarter-way-to-generate-time-since-with-a-datetime-objects
            // although in practice there are libraries these days that handle this for us

            var span = DateTime.Now.Subtract(from);
            var result = ConvertTimeSpanToFriendlyString(span);

            return result;
        }

        private string ConvertTimeSpanToFriendlyString(TimeSpan span, int level = 0)
        {
            var howLongAgo = "ago";

            if (level >= 2)
                return howLongAgo;

            if (span.Days > 1)
            {
                howLongAgo = $"{span.Days} days ago";
            }
            else if (span.Days == 1)
            {
                var timeSpan = new TimeSpan(span.Hours, span.Minutes, span.Seconds);
                var timeString = ConvertTimeSpanToFriendlyString(timeSpan, level + 1);

                howLongAgo = $"1 day {timeString}";
            }
            else if (span.Hours >= 1)
            {
                var hourSuffix = span.Hours > 1 ? "Hours" : "Hour";
                var minuteSpan = new TimeSpan(0, span.Minutes, span.Seconds);
                var minuteString = ConvertTimeSpanToFriendlyString(minuteSpan, level + 1);

                howLongAgo = $"{span.Hours} {hourSuffix} {minuteString}";
            }
            else if (span.Minutes >= 1)
            {
                var minuteSuffix = span.Minutes > 1 ? "Minutes" : "Minute";
                var secondSpan = new TimeSpan();
                var secondString = ConvertTimeSpanToFriendlyString(secondSpan, level + 1);

                howLongAgo = $"{span.Minutes} {minuteSuffix} {secondString}";
            }
            else if (span.Seconds >= 1)
            {
                var secondSuffix = span.Seconds > 1 ? "Seconds" : "Second";

                howLongAgo = $"{span.Seconds} {secondSuffix}";
            }

            return howLongAgo;
        }
    }
}
