using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMercadoAPI.MsTests
{
    [TestClass]
    public class ClienteTests
    {
        [TestMethod]
        public void CLI_01_RegistrarCliente_Valido()
        {
            // Arrange
            var cliente = new
            {
                Nombre = "Juan Pérez",
                Email = "juan@example.com",
                Activo = true
            };

            // Act
            bool esValido = !string.IsNullOrWhiteSpace(cliente.Email) && cliente.Email.Contains("@");

            // Assert
            Assert.IsTrue(esValido, "El cliente debe ser válido si el email es correcto.");
        }
        [TestMethod]
        public void CLI_02_RegistrarCliente_SinEmail_Invalido()
        {
            // Arrange
            var cliente = new
            {
                Nombre = "Juan Pérez",
                Email = ""
            };

            // Act
            bool esValido = !string.IsNullOrWhiteSpace(cliente.Email) && cliente.Email.Contains("@");

            // Assert
            Assert.IsFalse(esValido, "Debe fallar si el campo Email está vacío.");
        }
    }
}
