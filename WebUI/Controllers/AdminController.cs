using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        IGameRepository repository;
        public AdminController(IGameRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.Games);
        }
        public ViewResult Edit(int gameId)
        {
            Game game = repository.Games.FirstOrDefault(g => g.GameId == gameId);
            return View(game);
        }
        [HttpPost]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                repository.SaveGame(game);
                TempData["message"] = string.Format("Changing in game {0} has been saved!",game.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(game);
            }
        }
        [HttpPost]
        public ActionResult Delete(int gameId)
        {
            Game deleteGame = repository.DeleteGame(gameId);
            if (deleteGame!=null)
            {
                TempData["message"] = string.Format("Game {0} hasbeen deleted!", deleteGame.Name);
            }
            return RedirectToAction("Index");
        }
    }
}