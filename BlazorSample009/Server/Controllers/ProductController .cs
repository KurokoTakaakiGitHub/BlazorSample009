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

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }
    }
}