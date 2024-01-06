using Microsoft.AspNetCore.Mvc;
using RescueMarket.Context;

namespace RescueMarket.Controllers
{

    [Route("LoginProductor")]
    [ApiController]

    public class LoginProductorController : ControllerBase
    {
        public class LoginRequestProductor
        {
            public string Correo { get; set; }
            public string Contrasena { get; set; }

        }

        [HttpPost]
        public bool LoginProductor([FromBody] LoginRequestProductor loginRequest)
        {
            bool regreso = false;
            using (RMContext contexto = new RMContext())
            {
                var existe = contexto.Productores.SingleOrDefault(i => i.Correo == loginRequest.Correo && i.Contrasena == loginRequest.Contrasena);
                if(existe != null)
                {
                    regreso = true;
                }
                return regreso;
            }
        }
    }
}
