using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParadigmModular.Data;
using ParadigmModular.Infrastructure;
using ParadigmModular.Models;
using ParadigmModular.Models.ViewModels;

namespace ParadigmModular.Controllers
{
    public class CartController : Controller
    {
        private ParadigmModularContext dataContext;
        private Cart cart;
        private WatchCreator creator;

        public CartController(Cart cartService, ParadigmModularContext dbContext)
        {
            cart = cartService;
            dataContext = dbContext;
            creator = new WatchCreator(dataContext);
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = this.cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(string productId, string returnUrl)
        {
            var ids = productId.Split("-");
            Watch product = dataContext.Watches
            .FirstOrDefault(p => p.Id == int.Parse(ids[0]));
            creator.InitBuiltWatch(product, ids);
            if (product != null)
            {
                cart.AddItem(new SerializableWatchModel() { Id = product.Id, Name = product.Name,
                    Description = product.Description, Price = product.Price,
                    WatchImagePath = product.WatchImagePath }, 1);
            }
            Console.WriteLine(product);
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Watch product = dataContext.Watches
            .FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}