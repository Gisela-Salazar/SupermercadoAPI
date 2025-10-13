using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado.Entidades
{
    public class Compra
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCompra { get; set; }
        public bool Activo { get; set; } = true;
    }
}
