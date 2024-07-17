using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.ViewModels;
using Blog.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;


namespace Blog.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("v1/categories")]
        public async Task<IActionResult> GetAsync(
            [FromServices] BlogDataContext context)
        {
            try
            {
                var categories = await context.Categories
                    .AsNoTracking()
                    .ToListAsync();
                return Ok(new ResultViewModel<List<Category>>(categories));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Category>>("05x04 falha interna no servidor"));
            }

        }

        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] BlogDataContext context,
            [FromRoute] int id)
        {
            try
            {
                var categories = await context.Categories
              .AsNoTracking()
              .FirstOrDefaultAsync(x => x.Id == id);
                if (categories == null)
                    return NotFound(new ResultViewModel<Category>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Category>(categories));
            }
            catch
            {
                return StatusCode(500, "falha interna no servidor");
            }
            
        }


        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync(
            [FromServices] BlogDataContext context,
            [FromBody] EditorCategoryViewModel model)
        {
            if (!ModelState.IsValid)            
                return BadRequest(new ResultViewModel<List<string>>(ModelState.GetErros()));
            
            try
            {
                var category = new Category
                {
                    Id = 0,
                    Name = model.Name,
                    Slug = model.Slug.ToLower()
                };
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();

                return Created($"v1/categories/{category.Id}",new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500,new ResultViewModel<Category> ("05xe9 - Não foi possível incluir a categoria"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("05x10 - falha interna no servidor"));
            }
        }

        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> PutAsync(

          [FromServices] BlogDataContext context,
          [FromBody] EditorCategoryViewModel model,
          [FromRoute] int id)
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (category == null)
                {
                    return NotFound(new ResultViewModel<Category>("Conteúdo não encontrado"));
                }
                else
                {
                    category.Name = model.Name;
                    category.Slug = model.Slug;
                    context.Categories.Update(category);
                    await context.SaveChangesAsync();

                    return Ok(new ResultViewModel<Category>(category));
                }
            }
            catch (DbException ex)
            {
                return StatusCode(500, new ResultViewModel<Category>("não foi possível atualizar a categoria"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("falha interna no servidor"));
            }

        }

        [HttpDelete("v1/categories/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] BlogDataContext context,
            [FromRoute] int id)
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (category == null)
                {
                    return NotFound(new ResultViewModel<Category>("Conteúdo não encontrado"));
                }
                else
                {
                    context.Categories.Remove(category);
                    await context.SaveChangesAsync();
                }
                return Ok(new ResultViewModel<Category>(category));
            }
            catch (DbException ex)
            {
                return StatusCode(500, new ResultViewModel<Category>("05xe8 - não foi possível deletar a categoria"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Category>("05x11 - falha interna no servidor"));
            }


        }
    }
}
