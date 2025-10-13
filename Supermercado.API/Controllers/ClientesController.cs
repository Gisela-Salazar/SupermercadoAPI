using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermercado.Entidades;
using Supermercado.LogicaNegocio;

namespace Supermercado.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteBL _clienteBL;

        public ClientesController(ClienteBL clienteBL)
        {
            _clienteBL = clienteBL;
        }

        [HttpGet]
        public IActionResult GetClientes() => Ok(_clienteBL.GetClientes());

        [HttpPost]
        public IActionResult AddCliente([FromBody] Cliente cliente) => Ok(_clienteBL.AddCliente(cliente));

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, [FromBody] Cliente cliente) => Ok(_clienteBL.UpdateCliente(id, cliente));

        [HttpPatch("{id}/toggle")]
        public IActionResult ToggleCliente(int id) => Ok(_clienteBL.ToggleCliente(id));
    }
}