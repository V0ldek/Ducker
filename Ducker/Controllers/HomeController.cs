using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ducker.Data;
using Ducker.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using Ducker.Models;
using Microsoft.EntityFrameworkCore;

namespace Ducker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var ducks = _repository.Ducks.Include(d => d.User).Select(d => new DuckViewModel(d.Name, d.User.UserName));

            return View(ducks);
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
