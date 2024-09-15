﻿using Dima.Api.Data;
using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Orders;
using Dima.core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers
{
    public class ProductHandler(AppDbContext context) : IProductHandler
    {
        public async Task<PagedResponse<List<Product>?>> GetAllAsync(GetAllProductsRequest request)
        {
            try
            {
                var query = context.Products.AsNoTracking().Where(x => x.IsActive == true).OrderBy(x => x.Title);
                var products = await query.Skip((request.PageNumber-1)* request.PageSize).Take(request.PageSize).ToListAsync();
                var count = await query.CountAsync();
                return products is null ? new PagedResponse<List<Product>?>(null, 404, "Produtos não encontrados") : new PagedResponse<List<Product>?>(products, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Product>?>(null, 500, "Não foi possível obter os produtos");
            }
        }

        public async Task<Response<Product?>> GetBySlugAsync(GetProductBySlugRequest request)
        {
            try
            {
                var product = await context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.IsActive == true && x.Slug == request.Slug);
                return product is null ? new Response<Product?>(null, 404, "Produto não encontrado") : new Response<Product?>(product);
            }
            catch
            {
                return new Response<Product?>(null, 500, "Não foi possível obter o produto");
            }
            
        }
    }
}
