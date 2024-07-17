using Fina.Api.Data;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api.Handlers
{
    public class CategoryHandler(AppDbContext context) : ICategoryHandler
    {
        public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
        {
            var category = new Category
            {
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description
            };

            try
            {
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();

                return new Response<Category?>(category, 201, "Categoria criada com sucesso");
            }
            catch (DbUpdateException dbe)
            {
                Console.WriteLine(dbe.Message);
                return new Response<Category?>(null, 500, "Não foi possível criar a categoria");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Response<Category?>(null, 500, "Não foi possível criar a categoria");
            }
        }

        public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (category is null)
            {
                return new Response<Category?>(null, 404, "Categoria não encontrada");
            }

            try
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();

                return new Response<Category?>(category, message: "Categoria excluída com sucesso");
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Response<Category?>(null, message: "Não foi possível excluir categoria");
            }
        }

        public async Task<PagedResponse<List<Category?>>> GetAllAsync(GetAllCategoriesRequest request)
        {
            try
            {
                var query = context.Categories.AsNoTracking().Where(x => x.UserId == request.UserId).OrderBy(x => x.Title);

                var categories = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await context.Categories.CountAsync();

                return new PagedResponse<List<Category?>>(categories,count, request.PageNumber, request.PageSize);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new PagedResponse<List<Category?>>(null, 500, "Não foi possível obter as categorias");
            }

            
        }

        public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
        {
            try
            {
                var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                return category is null
                    ? new Response<Category?>(null, 404, "Categoria não encontrada")
                    : new Response<Category?>(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Response<Category?>(null,500, "Não foi possível obter categoria");
            }



        }

        public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
            if (category is null)
            {
                return new Response<Category?>(null, 404, "Categoria não encontrada");
            }

            try
            {
                category.Title = request.Title;
                category.Description = request.Description;
                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return new Response<Category?>(category, message: "Categoria atualizada com sucesso");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Response<Category?>(null, message: "Não foi possível atualizar categoria");
            }


        }
    }
}