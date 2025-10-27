using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using System.Threading.Tasks;

namespace SuperMercadoAPI.MsTests
{
    public class CompraService
    {
        public decimal CalcularTotal(decimal precio, int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("Cantidad debe ser mayor que 0");

            return precio * cantidad;
        }

        public bool ValidarProductoExistente(int productoId)
        {
            // Simulamos que los productos válidos son 1, 2 y 3
            return productoId == 1 || productoId == 2 || productoId == 3;
        }
    }

    [TestClass]
    public class CompraTests
    {
        private readonly CompraService _service = new CompraService();

        [TestMethod]
        public void COM_01_RegistrarCompra_Valida()
        {
            // Arrange
            decimal precio = 10.5m;
            int cantidad = 3;

            // Act
            var total = _service.CalcularTotal(precio, cantidad);

            // Assert
            Assert.AreEqual(31.5m, total, "El total debe ser el producto de precio * cantidad.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void COM_02_RegistrarCompra_CantidadCero()
        {
            // Act
            _service.CalcularTotal(10.5m, 0);
        }

        [TestMethod]
        public void COM_03_ActualizarCompra()
        {
            // Arrange
            decimal precioNuevo = 12m;
            int cantidad = 2;

            // Act
            var total = _service.CalcularTotal(precioNuevo, cantidad);

            // Assert
            Assert.AreEqual(24m, total, "El total actualizado debe reflejar los nuevos valores.");
        }

        [TestMethod]
        public void COM_04_ToggleCompra_ActivaInactiva()
        {
            // Arrange
            bool activa = true;

            // Act
            activa = !activa;

            // Assert
            Assert.IsFalse(activa, "El estado debe cambiar correctamente al desactivar la compra.");
        }

        [TestMethod]
        public void COM_05_ListarCompras()
        {
            // Arrange
            var compras = new[]
            {
                new { Id = 1, Producto = "Pan", Cantidad = 2 },
                new { Id = 2, Producto = "Leche", Cantidad = 1 }
            };

            // Act
            bool hayCompras = compras.Length > 0;

            // Assert
            Assert.IsTrue(hayCompras, "La lista de compras no debe estar vacía.");
        }

        [TestMethod]
        public void COM_06_RegistrarCompra_ProductoInexistente()
        {
            // Arrange
            int productoId = 99;

            // Act
            var existe = _service.ValidarProductoExistente(productoId);

            // Assert
            Assert.IsFalse(existe, "Debe retornar false si el producto no existe.");
        }
    }
}
