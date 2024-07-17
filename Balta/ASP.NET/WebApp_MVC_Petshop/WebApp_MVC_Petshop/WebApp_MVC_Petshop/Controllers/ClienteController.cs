using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_MVC_Petshop.Data;
using WebApp_MVC_Petshop.Data.Repositories;
using WebApp_MVC_Petshop.Models;

namespace WebApp_MVC_Petshop.Controllers
{
    public class ClienteController : Controller
    {
        private readonly Repository<Cliente> _repository;

        public ClienteController(Repository<Cliente> repository)
        {
            _repository = repository;
        }

        public IActionResult BuscarCliente()
        {
            return View();
        }

        public async Task<IActionResult> Getall()
        {
            return View(await _repository.GetAllClientes());
        }

        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _repository.GetById(id);
            return View(cliente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name")] Cliente cliente)
        {
            if (!ModelState.IsValid)            
                return BadRequest();                
            
            _repository.Create(cliente);
            return RedirectToAction(nameof(Getall));
        }        

        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _repository.GetById(id);
            if (cliente == null)            
                return NotFound();            
           
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(int id, [Bind("Id, Name")] Cliente entity)
        {
            var cliente = await _repository.GetById(entity.Id);
            if (cliente == null)            
                return BadRequest();         
            
            cliente.Name = entity.Name;
            _repository.Update(cliente);
            return RedirectToAction(nameof(Getall));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _repository.GetById(id);
            if (cliente == null)            
                return BadRequest();            

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _repository.GetById(id);
            if (cliente == null)            
                return BadRequest();
            
            _repository.Delete(cliente);
            return RedirectToAction(nameof(Getall));
        }

        public async Task<IActionResult> GetAllPets()
        {
            var pets = await _repository.GetAllPet();
            return View(pets);
        }

        public async Task<IActionResult> GetPets(int id)
        {
            var clientes = await _repository.GetById(id);
            var pets = new List<Pet>();
            foreach (var pet in clientes.Pets)
            {
                pets.Add(pet);
            }
            return View(pets);
        }

        public IActionResult BuscarPet()
        {
            return View();
        }

    }
}