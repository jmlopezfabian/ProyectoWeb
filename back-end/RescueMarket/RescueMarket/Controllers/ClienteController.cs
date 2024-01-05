using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RescueMarket.Context;
using RescueMarket.Model;

namespace RescueMarket.Controllers
{
    [Route("Clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (RMContext context = new RMContext())
            {
                var aux = context.Clientes;
                foreach(var item in aux)
                {
                    clientes.Add(new Cliente
                    {
                        Nombre_Usuario = item.Nombre_Usuario,
                        Correo = item.Correo,
                        Contraseña = item.Contraseña,
                        Apellido_Paterno = item.Apellido_Paterno,
                        Apellido_Materno = item.Apellido_Materno,
                        Nombre = item.Nombre,
                        Fecha_nacimiento = item.Fecha_nacimiento
                    });
                }
            }
            return new JsonResult(clientes);
        }
        [HttpPost]
        public JsonResult PostUsuarios([FromBody] Cliente clientes)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                context.Clientes.Add(clientes);
                context.SaveChanges();
                flag = true;
            }
            return new JsonResult(flag);
        }
        [HttpPatch]
        public JsonResult UpdateClientes([FromBody] Cliente clientes)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                var existe = context.Clientes.SingleOrDefault(c => c.Correo == clientes.Correo);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Clientes.Attach(clientes);
                    context.Entry(clientes).State = EntityState.Modified;
                    context.SaveChanges();
                    flag = true;
                }
            }
            return new JsonResult(flag);
        }
        [HttpDelete]
        public JsonResult DeleteClientes([FromBody] Cliente clientes)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                var existe = context.Clientes.SingleOrDefault(c => c.Correo == clientes.Correo);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Clientes.Attach(clientes);
                    context.Entry(clientes).State = EntityState.Deleted;
                    context.SaveChanges();
                    flag = true;
                }
            }
            return new JsonResult(flag);
        }
    }
}
