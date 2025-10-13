using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermercado.Entidades;
using Supermercado.LogicaNegocio;

namespace Supermercado.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ComprasController : ControllerBase
    {
        private readonly CompraBL _compraBL;

        public ComprasController(CompraBL compraBL)
        {
            _compraBL = compraBL;
        }

        [HttpGet]
        public IActionResult GetCompras() => Ok(_compraBL.GetCompras());

        [HttpPost]
        public IActionResult AddCompra([FromBody] Compra compra) => Ok(_compraBL.AddCompra(compra));

        [HttpPut("{id}")]
        public IActionResult UpdateCompra(int id, [FromBody] Compra compra) => Ok(_compraBL.UpdateCompra(id, compra));

        [HttpPatch("{id}/toggle")]
        public IActionResult ToggleCompra(int id) => Ok(_compraBL.ToggleCompra(id));
    }
}