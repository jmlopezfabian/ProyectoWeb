using RescueMarket.Context;
using RescueMarket.DTO;
using RescueMarket.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RescueMarket.Controllers
{
    [Route("DTO_Direcciones")]
    [ApiController]
    public class DTODireccionController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetDirecciones()
        {
            List<DTO_Direccion> direcciones = new List<DTO_Direccion>();

            using(RMContext context = new RMContext())
            {
                var aux = context.Direccion;
                foreach (var item in aux)
                {
                    direcciones.Add(new DTO_Direccion
                    {
                        Num_ext = item.Num_ext,
                        Calle = item.Calle,
                        Ciudad = item.Ciudad,
                        Codigo_Postal = item.Codigo_Postal
                    });
                }
            }
            return new JsonResult(direcciones);
        }
    }
}
