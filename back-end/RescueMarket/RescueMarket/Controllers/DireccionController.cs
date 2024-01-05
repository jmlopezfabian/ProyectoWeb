using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RescueMarket.Context;
using RescueMarket.Model;

namespace RescueMarket.Controllers
{
    [Route("Direcciones")]
    [ApiController]
    public class DireccionController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetDirecciones()
        {
            List<Direccion> direcciones = new List<Direccion>();
            using (RMContext context = new RMContext())
            {
                var aux = context.Direcciones;
                foreach(var item in aux)
                {
                    direcciones.Add(new Direccion
                    {
                        id = item.id,
                        Codigo_Postal = item.Codigo_Postal,
                        Num_ext = item.Num_ext,
                        Calle = item.Calle,
                        Ciudad = item.Ciudad,
                    });
                }
            }
            return new JsonResult(direcciones);
        }
        [HttpPost]
        public JsonResult PostDirecciones([FromBody] Direccion direcciones)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                context.Direcciones.Add(direcciones);
                context.SaveChanges();
                flag = true;
            }
            return new JsonResult(flag);
        }
        [HttpPatch]
        public JsonResult UpdateDirecciones([FromBody] Direccion direcciones)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                var existe = context.Direcciones.SingleOrDefault(d => d.Num_ext == direcciones.Num_ext);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Direcciones.Attach(direcciones);
                    context.Entry(direcciones).State = EntityState.Modified;
                    context.SaveChanges();
                    flag = true;
                }
            }
            return new JsonResult(flag);
        }
        [HttpDelete]
        public JsonResult DeleteDirecciones([FromBody] Direccion direcciones)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                var existe = context.Direcciones.SingleOrDefault(d => d.Num_ext == direcciones.Num_ext);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Direcciones.Attach(direcciones);
                    context.Entry(direcciones).State = EntityState.Deleted;
                    context.SaveChanges();
                    flag = true;
                }
            }
            return new JsonResult(flag);
        }
    }
}
