using RescueMarket.Context;
using RescueMarket.DTO;
using RescueMarket.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RescueMarket.Controllers
{
    [Route("DTOCompras")]
    [ApiController]
    public class DTOCompraController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetCompras()
        {
            List<DTO_Compra> compras = new List<DTO_Compra>();

            using (RMContext context = new RMContext())
            {
                var aux = context.Compra;
                foreach (var item in aux)
                {
                    compras.Add(new DTO_Compra
                    {
                        NumCompra = item.NumCompra,
                        FechaCompra = item.FechaCompra,
                        Cantidad = item.Cantidad,
                        ID_producto = item.ID_producto
                    });
                }
            }
            return new JsonResult(compras);
        }
    }
}
