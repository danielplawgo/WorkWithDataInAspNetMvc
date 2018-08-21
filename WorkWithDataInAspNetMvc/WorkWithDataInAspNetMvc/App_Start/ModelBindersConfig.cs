using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkWithDataInAspNetMvc.Infrastructure;

namespace WorkWithDataInAspNetMvc
{
    public class ModelBindersConfig
    {
        public static void Configure()
        {
            var dateBinder = new DateTimeBinder();

            ModelBinders.Binders.Add(typeof(DateTime), dateBinder);
            ModelBinders.Binders.Add(typeof(DateTime?), dateBinder);
        }
    }
}