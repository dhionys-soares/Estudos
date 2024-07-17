using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_MVC_Petshop.Models;

namespace WebApp_MVC_Petshop.Data.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async void Create(T entity)
        {
           await _context.AddAsync<T>(entity);
           _context.SaveChanges();
        }

        public async Task<List<Cliente>> GetAllClientes()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }
        public async Task<Cliente?> GetById(int id)
        {
            return await _context.Clientes
                .Include(x=>x.Pets)
                .FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<List<Pet>> GetAllPet()
        {
            return await _context.Pets.AsNoTracking().ToListAsync();
        }

        //public async Task<List<Cliente>> GetPetId(int id)
        //{
            
        //    //return await _context.Pets
        //    //    .Include(x=>x.Cliente)
        //    //    .Where(x => x.Id == id).ToListAsync();
        //}

        public void Update(T entity)
        {
             _context.Update<T>(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove<T>(entity);
            _context.SaveChanges();
        }
    }
}
