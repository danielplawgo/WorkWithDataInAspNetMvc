using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkWithDataInAspNetMvc.Infrastructure
{
    public class DateTimeBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = base.BindModel(controllerContext, bindingContext);

            if (bindingContext.ModelType == typeof(DateTime))
            {
                var date = (DateTime) value;

                return DateTime.SpecifyKind(date, DateTimeKind.Local);
            }

            if (bindingContext.ModelType == typeof(DateTime?))
            {
                var date = value as DateTime?;

                if (date.HasValue)
                {
                    return DateTime.SpecifyKind(date.Value, DateTimeKind.Local) as DateTime?;
                }
            }

            return value;
        }
    }
}