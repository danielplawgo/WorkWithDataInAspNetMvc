using AutoMapper;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkWithDataInAspNetMvc.Infrastructure;
using WorkWithDataInAspNetMvc.Models;
using WorkWithDataInAspNetMvc.ViewModels.Events;

namespace WorkWithDataInAspNetMvc.Controllers
{
    public partial class EventsController : Controller
    {
        private Lazy<IMapper> _mapper;

        protected IMapper Mapper
        {
            get { return _mapper.Value; }
        }

        private Lazy<DataContext> _dataContext;

        protected DataContext DataContext
        {
            get { return _dataContext.Value; }
        }

        public EventsController(Lazy<IMapper> mapper,
            Lazy<DataContext> dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        // GET: Events
        public virtual ActionResult Index()
        {
            var viewModels = Mapper.Map<List<EventViewModel>>(DataContext.Events);

            return View(viewModels);
        }

        public virtual ActionResult Create()
        {
            var viewModel = new EventViewModel()
            {
                Start = DateTime.Today.AddHours(12),
                End = DateTime.Today.AddHours(13)
            };

            return View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult Create(EventViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(viewModel);
            }

            var eventModel = Mapper.Map<Event>(viewModel);

            DataContext.Events.Add(eventModel);
            DataContext.SaveChanges();

            return RedirectToAction(MVC.Events.Index());
        }
    }
}