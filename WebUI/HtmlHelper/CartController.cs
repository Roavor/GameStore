using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Abstract;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
       
        public IGameRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IGameRepository repo,IOrderProcessor processor)
        {
            orderProcessor = processor;
            repository = repo;
        }
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
        public ViewResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart,int gameId,string returnUrl)
        {
            Game game = repository.Games
                .FirstOrDefault(g => g.GameId == gameId);
            if (game!=null)
            {
               cart.AddItem(game, 1);
            }
            return RedirectToAction("Index", new { returnUrl });

        }
        public RedirectToRouteResult RemoveFromCart(Cart cart,int gameId,string returnUrl)
        {
            Game game = repository.Games
                .FirstOrDefault(g => g.GameId == gameId);
            if (game!=null)
            {
               cart.RemoveLine(game);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout(Cart cart)
        {
            return View(new ShippingDetails());
        }
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}