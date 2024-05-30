using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Shop_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("All")]
        public IActionResult Get()
        {
            return Ok(productsService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute]int id)
        {
            return Ok(productsService.Get(id));
        }
    }
}
