using RescueMarket.Context;
using RescueMarket.DTO;
using RescueMarket.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RescueMarket.Controllers
{
    [Route("DTOClientes")]
    [ApiController]
    public class DTOClienteController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetClientes()
        {
            List<DTO_Cliente> clientes = new List<DTO_Cliente>();

            using(RMContext context = new RMContext())
            {
                var aux = context.ClientesDTO;
                foreach (var item in aux)
                {
                    clientes.Add(new DTO_Cliente
                    {
                        Correo = item.Correo,
                        Nombre_Usuario = item.Nombre_Usuario,
                        Nombre = item.Nombre
                    });
                }
            }
            return new JsonResult(clientes);
        }

        [HttpGet]
        public JsonResult GetclientesDTO([FromBody] string correo)
        {
            DTO_Cliente clientes = new DTO_Cliente();
            using (RMContext contexto = new RMContext())
            {
                var existe = contexto.ProductorDTO.SingleOrDefault(i => i.Correo == correo);
                if (existe != null)
                {
                    clientes.Correo = existe.Correo;
                    clientes.Nombre_Usuario = existe.Nombre_Usuario;
                    clientes.Nombre = existe.Nombre;
                }
            }

            return new JsonResult(clientes);
        }


        [HttpPost]
        public JsonResult PostClienteDTO([FromBody] DTO_Cliente nuevo_cliente)
        {
            bool flag = false;
            DTO_Cliente clientes = new DTO_Cliente();

            using (RMContext contexto = new RMContext())
            {
                var existe = contexto.ClientesDTO.SingleOrDefault(i => i.Correo == nuevo_cliente.Correo);

                if (existe == null)
                {
                    clientes.Correo = existe.Correo;
                    clientes.Nombre_Usuario = existe.Nombre_Usuario;
                    clientes.Nombre = existe.Nombre;
                    flag = true;
                }
            }

            return new JsonResult(clientes);
        }

    }
}
