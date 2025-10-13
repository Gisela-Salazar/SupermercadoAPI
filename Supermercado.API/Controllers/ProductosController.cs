using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermercado.Entidades;
using Supermercado.LogicaNegocio;

namespace Supermercado.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ProductoBL _productoBL;

        public ProductosController(ProductoBL productoBL)
        {
            _productoBL = productoBL;
        }

        [HttpGet]
        public IActionResult GetProductos() => Ok(_productoBL.GetProductos());

        [HttpPost]
        public IActionResult AddProducto([FromBody] Producto producto) => Ok(_productoBL.AddProducto(producto));

        [HttpPut("{id}")]
        public IActionResult UpdateProducto(int id, [FromBody] Producto producto) => Ok(_productoBL.UpdateProducto(id, producto));

        [HttpPatch("{id}/toggle")]
        public IActionResult ToggleProducto(int id) => Ok(_productoBL.ToggleProducto(id));
    }
}