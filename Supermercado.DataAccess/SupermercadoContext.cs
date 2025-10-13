using Microsoft.EntityFrameworkCore;
using Supermercado.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado.DataAccess
{
    public class SupermercadoContext : DbContext
    {
        public SupermercadoContext(DbContextOptions<SupermercadoContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Compra> Compras { get; set; }
    }
}
