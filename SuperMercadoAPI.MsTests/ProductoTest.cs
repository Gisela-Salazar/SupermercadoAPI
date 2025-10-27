using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Supermercado.DataAccess;
using Supermercado.Entidades;
using Supermercado.LogicaNegocio;
using System;
using System.Linq;

namespace SuperMercadoAPI.MsTests
{
    [TestClass]
    public class ProductoTest
    {
        private SupermercadoContext _context;
        private ProductoBL _productoBL;

        [TestInitialize]
        public void Setup()
        {
            // Crear una base en memoria única para cada test
            var options = new DbContextOptionsBuilder<SupermercadoContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new SupermercadoContext(options);
            _productoBL = new ProductoBL(_context);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Dispose();
        }

        [TestMethod]
        public void PRO_01_AgregarProducto_Valido()
        {
            var producto = new Producto { Nombre = "Manzana", Precio = 1.50m };
            var resultado = _productoBL.AddProducto(producto);

            Assert.IsNotNull(resultado);
            Assert.AreEqual("Manzana", resultado.Nombre);
            Assert.AreEqual(1.50m, resultado.Precio);
            Assert.IsTrue(resultado.Activo);
        }

        [TestMethod]
        public void PRO_02_ListarProductos_DevuelveLista()
        {
            _context.Productos.AddRange(
                new Producto { Nombre = "Manzana", Precio = 1.50m },
                new Producto { Nombre = "Pera", Precio = 2.00m }
            );
            _context.SaveChanges();

            var lista = _productoBL.GetProductos();

            Assert.IsTrue(lista.Count >= 2, "Debe devolver al menos dos productos.");
        }

        [TestMethod]
        public void PRO_03_ActualizarProducto_Existente()
        {
            var producto = new Producto { Nombre = "Pan", Precio = 0.50m };
            _context.Productos.Add(producto);
            _context.SaveChanges();

            var actualizado = new Producto { Nombre = "Pan Integral", Precio = 0.75m };
            var result = _productoBL.UpdateProducto(producto.Id, actualizado);

            Assert.IsNotNull(result);
            Assert.AreEqual("Pan Integral", result.Nombre);
            Assert.AreEqual(0.75m, result.Precio);
        }

        [TestMethod]
        public void PRO_04_ActualizarProducto_NoExistente()
        {
            var actualizado = new Producto { Nombre = "Leche", Precio = 1.25m };
            var result = _productoBL.UpdateProducto(999, actualizado);
            Assert.IsNull(result, "Debe devolver null si el producto no existe.");
        }

        [TestMethod]
        public void PRO_05_ToggleProducto_CambiaEstado()
        {
            var producto = new Producto { Nombre = "Huevos", Precio = 3.50m };
            _context.Productos.Add(producto);
            _context.SaveChanges();

            var result = _productoBL.ToggleProducto(producto.Id);
            Assert.IsFalse(result.Activo, "El estado debe invertirse correctamente.");
        }
    }
}
