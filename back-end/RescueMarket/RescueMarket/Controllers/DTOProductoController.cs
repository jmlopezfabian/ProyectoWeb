using RescueMarket.Context;
using RescueMarket.DTO;
using RescueMarket.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RescueMarket.Controllers
{
    [Route("DTO_Productos")]
    [ApiController]
    public class DTOProductoController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetProductos()
        {
            List<DTO_Producto> productos = new List<DTO_Producto>();

            using(RMContext context = new RMContext())
            {
                var aux = context.ProductoDTO;
                foreach (var item in aux)
                {
                    productos.Add(new DTO_Producto
                    {
                        ID_producto = item.ID_producto,
                        Nombre_Producto = item.Nombre_Producto,
                        Descripcion = item.Descripcion,
                        Precio = item.Precio,
                        URL = item.URL
                    });
                }
            }
            return new JsonResult(productos);
        }
    }
}
