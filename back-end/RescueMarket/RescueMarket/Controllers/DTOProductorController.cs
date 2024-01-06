using RescueMarket.Context;
using RescueMarket.DTO;
using RescueMarket.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RescueMarket.Controllers
{
    [Route("DTO_Productores")]
    [ApiController]
    public class DTOProductorController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetProductores()
        {
            List<DTO_Productor> productores = new List<DTO_Productor>();

            using(RMContext context = new RMContext())
            {
                var aux = context.ProductorDTO;
                foreach (var item in aux)
                {
                    productores.Add(new DTO_Productor
                    {
                        Correo = item.Correo,
                        Nombre_Usuario = item.Nombre_Usuario,
                        Nombre = item.Nombre,
                        Telefono = item.Telefono,
                        Num_ext = item.Num_ext,
                        Calle = item.Calle,
                        Ciudad = item.Ciudad,
                        Codigo_Postal = item.Codigo_Postal
                    });
                }
            }
            return new JsonResult(productores);
        }
    }
}
