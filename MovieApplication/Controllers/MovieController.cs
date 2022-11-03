using Microsoft.AspNetCore.Mvc;
using MovieApplication.Application;
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
            
            return View(result);
        }
    }
}
