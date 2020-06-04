using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParadigmModular.Data;
using ParadigmModular.Infrastructure;
using ParadigmModular.Models;
using ParadigmModular.Models.ViewModels;

namespace ParadigmModular.Controllers
{
    public class HomeController : Controller
    {
        ParadigmModularContext DB;
        WatchCreator WatchCreation;
        List<WatchViewModel> Watches;
        public HomeController(ParadigmModularContext db)
        {
            DB = db;
            WatchCreation = new WatchCreator(db);
            Watches = new List<WatchViewModel>();
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            DB.Watches.ToList().ForEach(item => Watches.Add(new WatchViewModel(item)));
            InitWatch();
            return View(Watches);
        }

        private void InitWatch()
        {
            foreach (var watch in Watches)
            {
                WatchCreation.InitWatch(watch.Watch);
            }
        }
       
    }
}