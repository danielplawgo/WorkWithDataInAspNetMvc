using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using WorkWithDataInAspNetMvc.Infrastructure;
using WorkWithDataInAspNetMvc.Mappers;
using WorkWithDataInAspNetMvc.Models;

namespace WorkWithDataInAspNetMvc.App_Start.AutofacModules
{
    public class DateServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.Register(ctx =>
            //    {
            //        var timezone = "";
            //        if (HttpContext.Current != null)
            //        {
            //            var cookie = HttpContext.Current.Request.Cookies.Get("timezone");
            //            if (cookie != null && string.IsNullOrEmpty(cookie.Value) == false)
            //            {
            //                timezone = HttpUtility.UrlDecode(cookie.Value);
            //            }
            //        }
            //        return new DateService(timezone);
            //    })
            //    .As<IDateService>()
            //    .SingleInstance();

            builder.RegisterType<DateService>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<DateTimeToDateTimeConverter>()
                .SingleInstance();
        }
    }
}