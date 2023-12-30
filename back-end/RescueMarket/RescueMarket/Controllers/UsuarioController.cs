using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RescueMarket.Context;
using RescueMarket.Model;

namespace RescueMarket.Controllers
{
    [Route("Usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (RMContext context = new RMContext())
            {
                var aux = context.Usuarios;
                foreach(var item in aux)
                {
                    usuarios.Add(new Usuario
                    {
                        Id = item.Id,
                        NombreUsuario = item.NombreUsuario,
                        CorreoElectronico = item.CorreoElectronico,
                        Contrasena = item.Contrasena,
                        ApellidoPaterno = item.ApellidoPaterno,
                        ApellidoMaterno = item.ApellidoMaterno,
                        Nombre = item.Nombre,
                        FechaNacimiento = item.FechaNacimiento
                    });
                }
            }
            return new JsonResult(usuarios);
        }
        [HttpPost]
        public JsonResult PostUsuarios([FromBody] Usuario usuarios)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                context.Usuarios.Add(usuarios);
                context.SaveChanges();
                flag = true;
            }
            return new JsonResult(flag);
        }
        [HttpPatch]
        public JsonResult UpdateUsuarios([FromBody] Usuario usuarios)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                var existe = context.Usuarios.SingleOrDefault(a => a.Id == usuarios.Id);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Usuarios.Attach(usuarios);
                    context.Entry(usuarios).State = EntityState.Modified;
                    context.SaveChanges();
                    flag = true;
                }
            }
            return new JsonResult(flag);
        }
        [HttpDelete]
        public JsonResult DeleteUsuarios([FromBody] Usuario usuarios)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                var existe = context.Usuarios.SingleOrDefault(a => a.Id == usuarios.Id);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Usuarios.Attach(usuarios);
                    context.Entry(usuarios).State = EntityState.Deleted;
                    context.SaveChanges();
                    flag = true;
                }
            }
            return new JsonResult(flag);
        }
    }
}
