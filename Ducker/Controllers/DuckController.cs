using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ducker.Data;
using Ducker.Data.Entities;
using Ducker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ducker.Controllers
{
    public class DuckController : Controller
    {
        private readonly IRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;

        public DuckController(IRepository repository, UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        [Authorize]
        public ActionResult Create() => View(new CreateDuckViewModel());

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateDuckViewModel duck)
        {
            _repository.Ducks.Add(new Duck { Name = duck.Name, Color = duck.ColorAsEnum, UserId = _userManager.GetUserId(User)});
            await _repository.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}