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



        [HttpPatch]
        public JsonResult PatchClienteDTO(string correo, [FromBody] DTO_Cliente clienteModificado)
        {
            using (RMContext contexto = new RMContext())
            {
                var clienteExistente = contexto.ClientesDTO.SingleOrDefault(c => c.Correo == correo);

                if (clienteExistente == null)
                {
                    return new JsonResult(new { error = "Cliente no encontrado" }) { StatusCode = 404 };
                }

                // Aplicar las modificaciones parciales
                if (clienteModificado.Nombre_Usuario != null)
                {
                    clienteExistente.Nombre_Usuario = clienteModificado.Nombre_Usuario;
                }

                if (clienteModificado.Nombre != null)
                {
                    clienteExistente.Nombre = clienteModificado.Nombre;
                }

                // Guardar los cambios en la base de datos
                contexto.SaveChanges();

                return new JsonResult(clienteExistente);
            }
        }


    }
}
