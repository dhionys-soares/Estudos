﻿using Blog.Data;
using Blog.Models;
using Blog.ViewModels;
using Blog.ViewModels.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Blog.Controllers
{
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpGet("v1/posts")]
        public async Task<IActionResult> Getasync([FromServices] BlogDataContext context, [FromQuery] int page = 0, [FromQuery] int pageSize = 25)
        {
            try
            {
                var count = await context.Posts
                                .AsNoTracking()
                                .CountAsync();

                var posts = await context.Posts
                    .AsNoTracking()
                    .Include(x => x.Category)
                    .Include(x => x.Author)
                    .Select(x => new ListPostsViewModel { Id = x.Id, Title = x.Title, Slug = x.Slug, LastUpdateDate = x.LastUpdateDate, Category = x.Category.Name, Author = $"{x.Author.Name} ({x.Author.Email})" })
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .OrderByDescending(x => x.LastUpdateDate)
                    .ToListAsync();

                return Ok(new ResultViewModel<dynamic>(new
                {
                    total = count,
                    page,
                    pageSize,
                    posts
                }));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Post>("500 - 05x04 - falha interna no servidor"));
            }

        }

        [HttpGet("v1/posts/{id:int}")]
        public async Task<IActionResult> DatailsAsync([FromServices] BlogDataContext context, [FromRoute] int id)
        {
            try
            {

                var post = await context.Posts
                    .AsNoTracking()
                    .Include(x => x.Author)
                    .ThenInclude(x => x.Roles)
                    .Include(x => x.Category)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (post == null)
                    return NotFound(new ResultViewModel<Post>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Post>(post));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Post>("500 - 05x04 - falha interna no servidor"));
            }
        }

        [HttpGet("v1/posts/category/{category}")]
        public async Task<IActionResult> GetByCategoryAsync([FromServices] BlogDataContext context, [FromRoute] string category, [FromQuery] int page = 0, [FromQuery] int pageSize = 25)
        {
            try
            {
                var count = await context.Posts.CountAsync();

                var posts = await context.Posts
                    .AsNoTracking()
                    .Include(x => x.Author)
                    .Include(x => x.Category)
                    .Where(x => x.Category.Slug == category)
                    .Select(x => new ListPostsViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Slug = x.Slug,
                        LastUpdateDate = x.LastUpdateDate,
                        Category = x.Category.Name,
                        Author = $"{x.Author.Name} ({x.Author.Email})"
                    })
                    .Skip(page)
                    .Take(pageSize)
                    .OrderByDescending(x => x.LastUpdateDate)
                    .ToListAsync();
                                
                return Ok(new ResultViewModel<dynamic>(new
                {
                    total = count,
                    page,
                    pageSize,
                    posts
                }));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Post>>("500 - 05x04 - falha interna no servidor"));
            }
        }

        [HttpGet("v1/posts/categories")]
        public async Task<IActionResult> GetCategoriesAsync([FromServices] BlogDataContext context, [FromServices] IMemoryCache cache)
        {
            try
            {
                var categories = cache.GetOrCreate(key: "CategoriesCache", factory: entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
                    return GetCategories(context);
                });
                return Ok(new ResultViewModel<List<Category>>(categories));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("05x04 - falha interna no servidor"));
            }
        }
        private List<Category> GetCategories(BlogDataContext context)
        {
            return context.Categories.ToList();
        }
        
    }
}
