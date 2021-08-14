using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorSample009.Shared;

namespace BlazorSample009.Client.Services 
{ 
    public interface IProductService
    {
        /// <summary>
        /// 製品全取得
        /// </summary>
        /// <returns></returns>
        Task<List<Product>> GetAllProducts();

        /// <summary>
        /// 製品追加
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> AddProduct(Product product);

        /// <summary>
        /// 製品更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> UpdateProduct(string id, Product product);

        /// <summary>
        /// 製品削除
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>HttpResponseMessage</returns>
        Task<HttpResponseMessage> DeleteProduct(string id);
    }

    /// <summary>
    /// 製品サービス・クライアント側
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        /// <summary>
        /// 製品全て取得
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetAllProducts()
        {
            return await _http.GetFromJsonAsync<List<Product>>($"api/Product");
        }

        /// <summary>
        /// 製品追加
        /// </summary>
        /// <param name="product"></param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> AddProduct(Product product)
        {
            return await _http.PostAsJsonAsync($"api/Product", product);
        }

        /// <summary>
        /// 製品更新
        /// </summary>
        /// <param name="product"></param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> UpdateProduct(string id, Product product)
        {
            return await _http.PutAsJsonAsync($"api/Product/{id}", product);
        }

        /// <summary>
        /// 製品削除
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> DeleteProduct(string id)
        {
            return await _http.DeleteAsync($"api/Product/{id}");
        }
    }
}