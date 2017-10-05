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
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
        public IGameRepository repository;
        public CartController(IGameRepository repo)
        {
            repository = repo;
        }
        public RedirectToRouteResult AddToCart(int gameId,string returnUrl)
        {
            Game game = repository.Games
                .FirstOrDefault(g => g.GameId == gameId);
            if (game!=null)
            {
                GetCart().AddItem(game, 1);
            }
            return RedirectToAction("Index", new { returnUrl });

        }
        public RedirectToRouteResult RemoveFromCart(int gameId,string returnUrl)
        {
            Game game = repository.Games
                .FirstOrDefault(g => g.GameId == gameId);
            if (game!=null)
            {
                GetCart().RemoveLine(game);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}