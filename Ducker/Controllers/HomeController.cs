using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ducker.Data;
using Ducker.Data.Entities;
using Ducker.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using Ducker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ducker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(IRepository repository, UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            IQueryable<Duck> ducks = _repository.Ducks;

            if (!User.IsInRole("Administrator"))
            {
                ducks = ducks.Where(d => d.UserId == _userManager.GetUserId(User));
            }

            var duckViewModels = ducks.Include(d => d.User).Select(d => new DuckViewModel(d.Name, d.User.UserName));

            return View(duckViewModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
