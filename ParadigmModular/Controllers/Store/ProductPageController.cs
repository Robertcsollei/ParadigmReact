using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParadigmModular.Data;
using ParadigmModular.Infrastructure;
using ParadigmModular.Models;
using ParadigmModular.Models.ViewModels;

namespace ParadigmModular.Controllers
{
    public class ProductPageController : Controller
    {
        private ParadigmModularContext DB;
        WatchCreator WatchCreation;
        WatchViewModel WatchVM;

        public ProductPageController(ParadigmModularContext db)
        {
            DB = db;
            WatchCreation = new WatchCreator(db);
        }

        public IActionResult Index(string watchId)
        {

            if (watchId.Length == 1)
            {
                WatchVM = new WatchViewModel(DB.Watches.Where(watch => watch.Id.Equals(int.Parse(watchId))).First());
                WatchCreation.InitWatch(WatchVM.Watch);
                WatchVM.GenerateSelectedItemIds();
                return View(WatchVM);
            }
            else
            {
                var ids = watchId.Split("-");
                WatchVM = new WatchViewModel(DB.Watches.Where(watch => watch.Id.Equals(int.Parse(ids[0]))).First());
                WatchCreation.InitBuiltWatch(WatchVM.Watch, ids);
                WatchVM.GenerateSelectedItemIds();
                return View(WatchVM);
            }
            
        }
    }
}