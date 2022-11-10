using Microsoft.AspNetCore.Mvc;
using MovieApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Components
{
    public class MovieMenu : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            var result = new List<Menu>()
            {
                new Menu() { MenuItem = "Scifi"},
                new Menu() { MenuItem = "Drama"},
                new Menu() { MenuItem = "Terror"},
            };

            return Task.FromResult(View(result) as IViewComponentResult);
        }

    }
}
