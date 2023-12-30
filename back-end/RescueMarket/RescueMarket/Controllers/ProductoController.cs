using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RescueMarket.Context;
using RescueMarket.Model;

namespace RescueMarket.Controllers
{
    [Route ("Productos")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public JsonResult ProductoGet()
        {
            List<Producto> productos = new List<Producto>();
            using (RMContext context = new RMContext())
            {
                var aux = context.Productos;
                foreach(var item in aux)
                {
                    productos.Add(new Producto
                    {
                        ID_producto = item.ID_producto,
                        Nombre_Producto = item.Nombre_Producto,
                        Descripcion = item.Descripcion,
                        Precio = item.Precio
                    });
                }
            }
            return new JsonResult(productos);
        }
        [HttpPost]
        public JsonResult ProductoPost([FromBody] Producto productos)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                context.Productos.Add(productos);
                context.SaveChanges();
                flag = true;
            }
            return new JsonResult(flag);
        }
        [HttpPatch]
        public JsonResult UpdateProducto([FromBody] Producto productos)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                var existe = context.Productos.SingleOrDefault(a => a.ID_producto == productos.ID_producto);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Productos.Attach(productos);
                    context.Entry(productos).State = EntityState.Modified;
                    context.SaveChanges();
                    flag = true;
                }
            }
            return new JsonResult(flag);
        }
        [HttpDelete]
        public JsonResult DeleteProducto([FromBody] Producto productos)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                var existe = context.Productos.SingleOrDefault(a => a.ID_producto == productos.ID_producto);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Productos.Attach(productos);
                    context.Entry(productos).State = EntityState.Deleted;
                    context.SaveChanges();
                    flag = true;
                }
            }
            return new JsonResult(flag);
        } 
    }
}
