using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkWithDataInAspNetMvc.App_Start.AutofacModules
{
    public class AutomapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var profiles = GetType().Assembly.GetTypes()
                .Where(t => typeof(Profile).IsAssignableFrom(t))
                .Select(t => (Profile)Activator.CreateInstance(t));

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.ConstructServicesUsing(t => AutofacConfig.Container.Resolve(t));

                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();
        }
    }
}