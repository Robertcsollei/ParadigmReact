using Microsoft.AspNetCore.Mvc;
using ParadigmModular.Data;
using ParadigmModular.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmModular.Components
{
    public class YouMayAlsoLikeViewComponent : ViewComponent
    {
        string watchName;
        private ParadigmModularContext DB;

        public YouMayAlsoLikeViewComponent(ParadigmModularContext dB)
        {
            DB = dB;
        }

        public IViewComponentResult Invoke(string watchName)
        {
            this.watchName = watchName;
            var listOfOtherWatches = DB.Watches.Where(item => !item.Name.Equals(this.watchName));
            return View(listOfOtherWatches);
        }
    }
}
