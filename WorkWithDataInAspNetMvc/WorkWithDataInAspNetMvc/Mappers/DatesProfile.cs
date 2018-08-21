using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WorkWithDataInAspNetMvc.Infrastructure;

namespace WorkWithDataInAspNetMvc.Mappers
{
    public class DatesProfile : Profile
    {
        public DatesProfile()
        {
            CreateMap<DateTime, DateTime>()
                .ConvertUsing<DateTimeToDateTimeConverter>();
        }
    }

    public class DateTimeToDateTimeConverter : ITypeConverter<DateTime, DateTime>
    {
        private IDateService _dateService;

        public DateTimeToDateTimeConverter(IDateService dateService)
        {
            _dateService = dateService;
        }

        public DateTime Convert(DateTime source, DateTime destination, ResolutionContext context)
        {
            if (source.Kind == DateTimeKind.Unspecified)
            {
                source = DateTime.SpecifyKind(source, DateTimeKind.Utc);
            }

            if (source.Kind == DateTimeKind.Local)
            {
                return _dateService.ConvertToUtc(source);
            }

            return _dateService.ConvertToLocal(source);
        }
    }
}