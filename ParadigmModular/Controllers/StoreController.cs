using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParadigmModular.Data;
using ParadigmModular.Infrastructure;
using ParadigmModular.Models.ViewModels;

namespace ParadigmModular.Controllers
{
    public class StoreController : Controller
    {

        ParadigmModularContext DB;
        WatchCreator WatchCreation;
        List<WatchViewModel> Watches;

        public StoreController(ParadigmModularContext db)
        {
            DB = db;
            WatchCreation = new WatchCreator(db);
            Watches = new List<WatchViewModel>();
        }

        public IActionResult Index()
        {
            DB.Watches.ToList().ForEach(item => Watches.Add(new WatchViewModel(item)));
            InitWatches();
            return View(Watches);
        }

        private void InitWatches()
        {
            foreach (var watch in Watches)
            {
                WatchCreation.InitWatch(watch.Watch);
            }
        }
    }
}