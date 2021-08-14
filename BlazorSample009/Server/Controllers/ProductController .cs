using BlazorSample009.Server.Servicies;
using BlazorSample009.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Controllers
{
    /// <summary>
    /// 製品コントローラー
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly ILogger _logger;

        public ProductController(IProductService productService, ILoggerFactory loggerFactory)
        {
            _productService = productService;
            _logger = loggerFactory.CreateLogger("DataAccessPostgreSqlProvider");
        }

        /// <summary>
        /// 製品全取得
        /// </summary>
        /// <returns>製品</returns>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }

        /// <summary>
        /// 製品追加
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            return Ok(await _productService.AddProduct(product));
        }

        /// <summary>
        /// 製品更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(string id, Product product)
        {
            return Ok(await _productService.UpdateProduct(id, product));
        }

        /// <summary>
        /// 製品削除
        /// </summary>
        /// <param name="id">選択した製品Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            return Ok(await _productService.DeleteProduct(id));
        }
    }
}