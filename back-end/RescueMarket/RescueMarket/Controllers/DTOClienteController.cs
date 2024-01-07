using RescueMarket.Context;
using RescueMarket.DTO;
using RescueMarket.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RescueMarket.Controllers
{
    [Route("DTOClientes")]
    [ApiController]
    public class DTOClienteController : ControllerBase
    {
        [HttpGet]
        [Route("GetClientesDTO")]
        public JsonResult GetClientes()
        {
            List<DTO_Cliente> clientes = new List<DTO_Cliente>();

            using (RMContext context = new RMContext())
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

        public JsonResult GetclientesDTO([FromQuery] string correo)
        {
            DTO_Cliente cliente = new DTO_Cliente();
            using (RMContext contexto = new RMContext())
            {
                var existe = contexto.ProductorDTO.SingleOrDefault(i => i.Correo == correo);
                if (existe != null)
                {
                    cliente.Correo = existe.Correo;
                    cliente.Nombre_Usuario = existe.Nombre_Usuario;
                    cliente.Nombre = existe.Nombre;
                }
            }

            return new JsonResult(cliente);
        }


        [HttpPost]
        public JsonResult PostClienteDTO([FromBody] DTO_Cliente nuevo_cliente)
        {
            bool flag = false;

            using (RMContext contexto = new RMContext())
            {
                var existe = contexto.ClientesDTO.SingleOrDefault(i => i.Correo == nuevo_cliente.Correo);

                if (existe == null)
                {
                    contexto.ClientesDTO.Add(nuevo_cliente);
                    contexto.SaveChanges();
                    flag = true;
                }
            }

            return new JsonResult(flag);
        }



        [HttpPatch]
        public JsonResult PatchClienteDTO(string correo, [FromBody] DTO_Cliente clienteModificado)
        {
            bool flag = false;
            using (RMContext contexto = new RMContext())
            {
                var clienteExistente = contexto.ClientesDTO.SingleOrDefault(c => c.Correo == clienteModificado.Correo);

                if (clienteExistente == null)
                {
                    return new JsonResult(new { error = "Cliente no encontrado" }) { StatusCode = 404 };
                }


                else
                {
                    contexto.Entry(clienteExistente).State = EntityState.Detached;
                    contexto.ClientesDTO.Attach(clienteModificado);
                    contexto.Entry(clienteModificado).State = EntityState.Modified;
                    contexto.SaveChanges();
                    flag = true;

                }

                return new JsonResult(flag);
            }
        }




        [HttpDelete]
        public JsonResult DeleteClienteDTO([FromBody] DTO_Cliente clienteModificado)
        {
            bool flag = false;
            using (RMContext contexto = new RMContext())
            {
                var clienteExistente = contexto.ClientesDTO.SingleOrDefault(c => c.Correo == clienteModificado.Correo);

                if (clienteExistente == null)
                {
                    return new JsonResult(new { error = "Cliente no encontrado" }) { StatusCode = 404 };
                }


                else
                {
                    contexto.Entry(clienteExistente).State = EntityState.Detached;
                    contexto.ClientesDTO.Attach(clienteModificado);
                    contexto.Entry(clienteModificado).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    flag = true;

                }

                return new JsonResult(flag);
            }
        }
    }
}
