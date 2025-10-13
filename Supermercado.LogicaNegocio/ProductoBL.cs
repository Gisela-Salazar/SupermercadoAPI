using Supermercado.DataAccess;
using Supermercado.Entidades;

namespace Supermercado.LogicaNegocio
{
    public class ProductoBL
    {
        private readonly SupermercadoContext _context;

        public ProductoBL(SupermercadoContext context)
        {
            _context = context;
        }

        public List<Producto> GetProductos() => _context.Productos.ToList();

        public Producto AddProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return producto;
        }

        public Producto UpdateProducto(int id, Producto producto)
        {
            var existente = _context.Productos.Find(id);
            if (existente == null) return null;

            existente.Nombre = producto.Nombre;
            existente.Precio = producto.Precio;
            _context.SaveChanges();
            return existente;
        }

        public Producto ToggleProducto(int id)
        {
            var existente = _context.Productos.Find(id);
            if (existente == null) return null;

            existente.Activo = !existente.Activo;
            _context.SaveChanges();
            return existente;
        }
    }
}