using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkWithDataInAspNetMvc.Models;
using WorkWithDataInAspNetMvc.ViewModels.Events;

namespace WorkWithDataInAspNetMvc.Mappers
{
    public class EventsProfile : Profile
    {
        public EventsProfile()
        {
            CreateMap<Event, EventViewModel>();
        }
    }
}