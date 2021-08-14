using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorSample009.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorSample009.Server.Servicies
{
    public interface IProductService
    {
        /// <summary>
        /// 製品全取得
        /// </summary>
        /// <returns>製品</returns>
        Task<List<Product>> GetAllProducts();

        /// <summary>
        /// 追加
        /// </summary>
        /// <returns>製品</returns>
        Task<int> AddProduct(Product product);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="product">製品</param>
        /// <returns></returns>
        Task<int> UpdateProduct(string id, Product product);
        
        /// <summary>
        /// 削除
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        Task<int> DeleteProduct(string id);

    }

    /// <summary>
    /// 製品サービス・Server側
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">コンテキスト</param>
        public ProductService(DataContext context)
        {
              _context = context;
        }

        /// <summary>
        /// 製品取得
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetAllProducts()
        {
            using (_context)
            {
                return await _context.Products.ToListAsync();
            }
        }

        /// <summary>
        /// 追加
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<int> AddProduct(Product product)
        {
            using (_context)
            {
                await _context.Products.AddAsync(product);
                return await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<int> UpdateProduct(string id, Product product)
        {
            using (_context)
            {
                var updateProduct = _context.Products.FirstOrDefault(x => x.Id == id);
                
                if (updateProduct == null)
                {
                    return int.MaxValue;
                }

                updateProduct.Id = product.Id;
                updateProduct.Name = product.Name;
                updateProduct.Price = product.Price;
                return await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 削除
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public async Task<int> DeleteProduct(string id)
        {
            using (_context)
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == id);
                _context.Products.Remove(product);
                return await _context.SaveChangesAsync();
            }
        }

    }
}