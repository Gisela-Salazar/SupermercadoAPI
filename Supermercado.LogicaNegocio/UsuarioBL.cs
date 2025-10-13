using Supermercado.DataAccess;
using Supermercado.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado.LogicaNegocio
{
        public class UsuarioBL
        {
            private readonly SupermercadoContext _context;

            public UsuarioBL(SupermercadoContext context)
            {
                _context = context;
            }

            public Usuario? Login(string username, string password)
            {
                return _context.Usuarios.FirstOrDefault(u => u.Username == username && u.PasswordHash == password);
            }
        }
}
