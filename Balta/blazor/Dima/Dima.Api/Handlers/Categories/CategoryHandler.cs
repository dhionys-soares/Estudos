using Dima.Api.Data;
using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Categories;
using Dima.core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers.Categories
{
    public class CategoryHandler(AppDbContext Context) : ICategoryHandler
    {
        public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
        {
            try
            {
                var category = new Category
                {
                    UserId = request.UserId,
                    Title = request.Title,
                    Description = request.Description
                };
                await Context.Categories.AddAsync(category);
                await Context.SaveChangesAsync();

                return new Response<Category?>(category, 201, "Categoria criada com sucesso!");
            }
            catch
            {
                return new Response<Category?>(null, 500, "Não foi possível criar categoria.");
            }

        }

        public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
        {
            try
            {
                var category = await Context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (category is null)
                    return new Response<Category?>(null, 404, "Categoria não encontrada.");

                Context.Categories.Remove(category);
                await Context.SaveChangesAsync();

                return new Response<Category?>(category, 200, "Categoria deletada com sucesso.");
            }
            catch
            {
                return new Response<Category?>(null, 500, "Não foi possível deletar a categoria.");
            }
        }

        public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesRequest request)
        {
            try
            {
                var query = Context.Categories
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId)
                .OrderBy(x => x.Title);

                var categories = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

                var count = await query.CountAsync();

                return categories is null
                    ? new PagedResponse<List<Category>?>(null, 404, "Categorias não encontradas.")
                    : new PagedResponse<List<Category>?>(categories, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Category>?>(null, 500, "Não foi possível obter as categorias.");
            }

        }

        public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
        {
            try
            {
                var category = await Context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                return category is null ? new Response<Category?>(null, 404, "Categoria não encontrada.") : new Response<Category?>(category);
            }
            catch
            {
                return new Response<Category?>(null, 500, "Não foi possível obter a categoria.");
            }
        }

        public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
        {
            try
            {
                var category = await Context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (category is null)
                    return new Response<Category?>(null, 404, "Categoria não encontrada.");

                category.Title = request.Title;
                category.Description = request.Description;

                Context.Categories.Update(category);
                await Context.SaveChangesAsync();

                return new Response<Category?>(category);
            }
            catch
            {
                return new Response<Category?>(null, 500, "Não foi possível atualizar a categoria.");
            }

        }
    }
}
