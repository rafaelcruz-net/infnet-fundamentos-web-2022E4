using Microsoft.AspNetCore.Mvc;
using MovieApplication.Application;
using MovieApplication.Application.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Controllers
{
    public class MovieController : Controller
    {
        private MovieManager MovieManager { get; set; }

        public MovieController()
        {
            MovieManager = new MovieManager();
        }

        public IActionResult Index()
        {
            var result = MovieManager.ObterTodos();
            ViewBag.ShowCard = true;
            ViewBag.DarkMode = true;
            return View(result);
        }

        public IActionResult Detail(int movieId)
        {
            var result = MovieManager.ObterPorId(movieId);

            return View(result);
        }


        public IActionResult Search(string query)
        {
            var result = MovieManager.Search(query);

            ViewBag.Search = $"Você está pesquisando por: {query}";

            return View(result);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Movie model)
        {
            MovieManager.Salvar(model);

            return RedirectToAction("Index");
        }

    }
}
