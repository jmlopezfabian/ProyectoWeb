using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RescueMarket.Context;
using RescueMarket.Model;

namespace RescueMarket.Controllers
{
    [Route("Compras")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetCompras()
        {
            List<Compra> compras = new List<Compra>();
            using (RMContext context = new RMContext())
            {
                var aux = context.Compras;
                foreach(var item in aux)
                {
                    compras.Add(new Compra
                    {
                        NumCompra = item.NumCompra,
                        FechaCompra = item.FechaCompra,
                        Cantidad = item.Cantidad,
                        ID_cliente = item.ID_cliente,
                        ID_producto = item.ID_producto,
                        ID_productor = item.ID_productor,
                    });
                }
            }
            return new JsonResult(compras);
        }
        [HttpPost]
        public JsonResult PostCompras([FromBody] Compra compras)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                context.Compras.Add(compras);
                context.SaveChanges();
                flag = true;
            }
            return new JsonResult(flag);
        }
        [HttpPatch]
        public JsonResult UpdateCompras([FromBody] Compra compras)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                var existe = context.Compras.SingleOrDefault(b => b.NumCompra == compras.NumCompra);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Compras.Attach(compras);
                    context.Entry(compras).State = EntityState.Modified;
                    context.SaveChanges();
                    flag = true;
                }
            }
            return new JsonResult(flag);
        }
        [HttpDelete]
        public JsonResult DeleteCompras([FromBody] Compra compras)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                var existe = context.Compras.SingleOrDefault(b => b.NumCompra == compras.NumCompra);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Compras.Attach(compras);
                    context.Entry(compras).State = EntityState.Deleted;
                    context.SaveChanges();
                    flag = true;
                }
            }
            return new JsonResult(flag);
        }
    }
}
