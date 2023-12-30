using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RescueMarket.Context;
using RescueMarket.Model;

namespace RescueMarket.Controllers
{
    [Route ("Productores")]
    [ApiController]
    public class ProductorController : Controller
    {
        [HttpGet]
        public JsonResult GetProductor()
        {
            List<Productor> productores = new List<Productor>();
            using (RMContext context = new RMContext())
            {
                var aux = context.Productores;
                foreach(var item in aux)
                {
                    productores.Add(new Productor
                    {
                        ID_productor = item.ID_productor,
                        Nombre_Usuario = item.Nombre_Usuario,
                        Correo = item.Correo,
                        Contraseña = item.Contraseña,
                        Nombre = item.Nombre,
                        Apellido_Paterno = item.Apellido_Paterno,
                        Apellido_Materno = item.Apellido_Materno,
                        Fecha_nacimiento = item.Fecha_nacimiento,
                        Telefono = item.Telefono,
                        Dirección = item.Dirección
                    });
                }
            }
            return new JsonResult(productores);
        }
        [HttpPost]
        public JsonResult ProductorPost([FromBody] Productor productores)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                context.Productores.Add(productores);
                context.SaveChanges();
                flag = true;
            }
            return new JsonResult(flag);
        }
        [HttpPatch]
        public JsonResult UpdateProductor([FromBody] Productor productores)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                var existe = context.Productores.SingleOrDefault(a => a.ID_productor == productores.ID_productor);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Productores.Attach(productores);
                    context.Entry(productores).State = EntityState.Modified;
                    context.SaveChanges();
                    flag = true;
                }
            }
            return new JsonResult(flag);
        }
        [HttpDelete]
        public JsonResult DeleteProductor([FromBody] Productor productores)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                var existe = context.Productores.SingleOrDefault(a => a.ID_productor == productores.ID_productor);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Productores.Attach(productores);
                    context.Entry(productores).State = EntityState.Deleted;
                    context.SaveChanges();
                    flag = true;
                }
            }
            return new JsonResult(flag); ;
        }
    }
}
