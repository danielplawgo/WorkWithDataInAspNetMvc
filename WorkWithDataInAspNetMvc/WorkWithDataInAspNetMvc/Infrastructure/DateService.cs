using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NodaTime.TimeZones;

namespace WorkWithDataInAspNetMvc.Infrastructure
{
    public class DateService : IDateService
    {
        public DateTime ConvertToUtc(DateTime dateTime)
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(GetTimezone());
            var date = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
            return TimeZoneInfo.ConvertTimeToUtc(date, timeZone);
        }

        public DateTime ConvertToLocal(DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                dateTime, GetTimezone());
        }

        private string GetTimezone()
        {
            var tzdbId = "";
            if (HttpContext.Current != null)
            {
                var cookie = HttpContext.Current.Request.Cookies.Get("timezone");
                if (cookie != null && string.IsNullOrEmpty(cookie.Value) == false)
                {
                    tzdbId = HttpUtility.UrlDecode(cookie.Value);
                }
            }

            if (string.IsNullOrEmpty(tzdbId) == false)
            {
                var mappings = TzdbDateTimeZoneSource.Default.WindowsMapping.MapZones;
                var map = mappings.FirstOrDefault(x =>
                    x.TzdbIds.Any(z => z.Equals(tzdbId, StringComparison.OrdinalIgnoreCase)));

                if (map != null)
                {
                    return map.WindowsId;
                }
            }

            return "Central Standard Time";
        }
    }

    public interface IDateService
    {
        DateTime ConvertToUtc(DateTime dateTime);

        DateTime ConvertToLocal(DateTime dateTime);
    }
}