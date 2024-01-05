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
                var aux = context.Productor;
                foreach (var item in aux)
                {
                    productores.Add(new DTO_Productor
                    {
                        Nombre_Usuario = item.Nombre_Usuario,
                        Direccion = item.Direccion,
                        Nombre = item.Nombre,
                        Telefono = item.Telefono
                    });
                }
            }
            return new JsonResult(productores);
        }
        [HttpPost]
        public bool LoginMethod([FromBody] string admin, string Contra)
        {
            bool comprobacion = false;
            using (RMContext context = new RMContext())
            {
                var existe = context.Productor.SingleOrDefault(u=>u.Nombre_Usuario == admin && u.Contraseña == Contra);
                if(existe != null)
                {
                    comprobacion = true;
                }
                return comprobacion;
            }
        }
    }
}
