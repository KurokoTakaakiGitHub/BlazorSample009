using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorSample009.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorSample009.Server.Servicies
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
    }

    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
              _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            using (_context)
            {
                return await _context.Products.ToListAsync();
            }
        }
    }
}