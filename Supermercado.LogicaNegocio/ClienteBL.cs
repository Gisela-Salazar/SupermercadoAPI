using Supermercado.DataAccess;
using Supermercado.Entidades;

namespace Supermercado.LogicaNegocio
{
    public class ClienteBL
    {
        private readonly SupermercadoContext _context;

        public ClienteBL(SupermercadoContext context)
        {
            _context = context;
        }

        public List<Cliente> GetClientes() => _context.Clientes.ToList();

        public Cliente AddCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public Cliente UpdateCliente(int id, Cliente cliente)
        {
            var existente = _context.Clientes.Find(id);
            if (existente == null) return null;

            existente.Nombre = cliente.Nombre;
            existente.Email = cliente.Email;
            _context.SaveChanges();
            return existente;
        }

        public Cliente ToggleCliente(int id)
        {
            var existente = _context.Clientes.Find(id);
            if (existente == null) return null;

            existente.Activo = !existente.Activo;
            _context.SaveChanges();
            return existente;
        }
    }
}