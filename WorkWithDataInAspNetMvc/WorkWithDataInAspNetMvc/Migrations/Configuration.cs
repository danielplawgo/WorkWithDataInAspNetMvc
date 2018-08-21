using Bogus;
using WorkWithDataInAspNetMvc.Models;

namespace WorkWithDataInAspNetMvc.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WorkWithDataInAspNetMvc.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WorkWithDataInAspNetMvc.Models.DataContext context)
        {
            if (context.Events.Any() == false)
            {
                var events = new Faker<Event>()
                    .RuleFor(e => e.Start,
                        f => f.Date.Between(new DateTime(2018, 1, 1), new DateTime(2018, 4, 30)).ToUniversalTime())
                    .RuleFor(e => e.End, (f, e) => e.Start.AddHours(f.Random.Int(1, 5)))
                    .RuleFor(e => e.Name, f => string.Format("{0} overview", f.Commerce.ProductName()))
                    .Generate(10)
                    .OrderBy(e => e.Start)
                    .ToArray();

                context.Events.AddOrUpdate(e => e.Name, events);
            }
        }
    }
}
