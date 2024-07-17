using Microsoft.AspNetCore.Mvc;
using WebApp_MVC_Petshop.Data.Repositories;
using WebApp_MVC_Petshop.Models;
using WebApp_MVC_Petshop.ViewModels;

namespace WebApp_MVC_Petshop.Controllers
{
    public class AccountController : Controller
    {
        private readonly Repository<Cliente> _repository;

        public AccountController(Repository<Cliente> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var cliente = new Cliente
            {
                Name = model.Name,
                Email = model.Email,
                PasswordHash = model.PasswordHash
            };
            _repository.Create(cliente);
            return RedirectToAction("Index","Home");
        }
    }
}
