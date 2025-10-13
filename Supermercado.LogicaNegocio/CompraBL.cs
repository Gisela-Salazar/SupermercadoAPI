using Supermercado.DataAccess;
using Supermercado.Entidades;

namespace Supermercado.LogicaNegocio
{
    public class CompraBL
    {
        private readonly SupermercadoContext _context;

        public CompraBL(SupermercadoContext context)
        {
            _context = context;
        }

        public List<Compra> GetCompras() => _context.Compras.ToList();

        public Compra AddCompra(Compra compra)
        {
            _context.Compras.Add(compra);
            _context.SaveChanges();
            return compra;
        }

        public Compra UpdateCompra(int id, Compra compra)
        {
            var existente = _context.Compras.Find(id);
            if (existente == null) return null;

            existente.ClienteId = compra.ClienteId;
            existente.ProductoId = compra.ProductoId;
            existente.Cantidad = compra.Cantidad;
            existente.FechaCompra = compra.FechaCompra;
            _context.SaveChanges();
            return existente;
        }

        public Compra ToggleCompra(int id)
        {
            var existente = _context.Compras.Find(id);
            if (existente == null) return null;

            existente.Activo = !existente.Activo;
            _context.SaveChanges();
            return existente;
        }
    }
}