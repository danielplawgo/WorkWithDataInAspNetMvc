﻿using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkWithDataInAspNetMvc
{
    public class AutofacConfig
    {
        public static IContainer Container { get; private set; }

        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(typeof(AutofacConfig).Assembly);

            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));

            return Container;
        }
    }
}