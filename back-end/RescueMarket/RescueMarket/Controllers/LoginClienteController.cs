using Microsoft.AspNetCore.Mvc;
using RescueMarket.Context;

namespace RescueMarket.Controllers
{
    [Route("LoginCliente")]
    [ApiController]
    public class LoginClienteController : ControllerBase
    {
        public class LoginRequestCliente
        {
            public string Correo { get; set; }
            public string Contrasena { get; set; }
        }

        [HttpPost]
        public bool LoginCliente([FromBody] LoginRequestCliente loginRequest)
        {
            bool regreso = false;
            using (RMContext contexto = new RMContext())
            {
                var existe = contexto.Clientes.SingleOrDefault(i => i.Correo == loginRequest.Correo && i.Contrasena == loginRequest.Contrasena);
                if (existe != null)
                {
                    regreso = true;
                }
                return regreso;
            }
        }
    }

}
