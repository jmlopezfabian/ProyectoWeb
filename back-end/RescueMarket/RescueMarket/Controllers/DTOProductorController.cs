using RescueMarket.Context;
using RescueMarket.DTO;
using RescueMarket.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Pqc.Crypto.Falcon;

namespace RescueMarket.Controllers
{
    [Route("DTO_Productores")]

    [ApiController]
    public class DTOProductorController : ControllerBase
    {
        [HttpGet]
        [Route("GetProductoresDTO")]
        public JsonResult GetProductoresDTO()
        {
            List<DTO_Productor> productores = new List<DTO_Productor>();

            using (RMContext context = new RMContext())
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

        [HttpGet]
        public JsonResult GetproductorDTO([FromQuery] string correo)
        {
            DTO_Productor productor = new DTO_Productor();
            using (RMContext contexto = new RMContext())
            {
                var existe = contexto.ProductorDTO.SingleOrDefault(i => i.Correo == correo);
                if (existe != null)
                {
                    productor.Correo = existe.Correo;
                    productor.Nombre_Usuario = existe.Nombre_Usuario;
                    productor.Nombre = existe.Nombre;
                    productor.Telefono = existe.Telefono;
                    productor.Num_ext = existe.Num_ext;
                    productor.Calle = existe.Calle;
                    productor.Ciudad = existe.Ciudad;
                    productor.Codigo_Postal = existe.Codigo_Postal;
                }
            }

            return new JsonResult(productor);
        }

        [HttpGet]
        [Route("GetProductorDTO_USER")]
        public JsonResult GetproductorDTO_USER([FromQuery] string user_name)
        {
            DTO_Productor productor = new DTO_Productor();
            using (RMContext contexto = new RMContext())
            {
                var existe = contexto.ProductorDTO.SingleOrDefault(i => i.Nombre_Usuario == user_name);
                if (existe != null)
                {
                    productor.Correo = existe.Correo;
                    productor.Nombre_Usuario = existe.Nombre_Usuario;
                    productor.Nombre = existe.Nombre;
                    productor.Telefono = existe.Telefono;
                    productor.Num_ext = existe.Num_ext;
                    productor.Calle = existe.Calle;
                    productor.Ciudad = existe.Ciudad;
                    productor.Codigo_Postal = existe.Codigo_Postal;
                }
            }

            return new JsonResult(productor);
        }

        [HttpPost]
        public JsonResult PostProductorDTO([FromBody] DTO_Productor nuevo_productor)
        {
            bool flag = false;

            using (RMContext contexto = new RMContext())
            {
                var existe = contexto.ProductorDTO.SingleOrDefault(i => i.Correo == nuevo_productor.Correo);

                if (existe == null)
                {
                    contexto.ProductorDTO.Add(nuevo_productor);
                    contexto.SaveChanges();
                    flag = true;
                }
            }

            return new JsonResult(flag);
        }

        [HttpPatch]
        public IActionResult PatchProductorDTO([FromBody] DTO_Productor productorModificado)
        {
            bool flag = false;
            using (RMContext contexto = new RMContext())
            {
                var productorExistente = contexto.ProductorDTO.SingleOrDefault(p => p.Correo == productorModificado.Correo);

                if (productorExistente != null)
                {
                    contexto.Entry(productorExistente).State = EntityState.Detached;
                    contexto.ProductorDTO.Attach(productorModificado);
                    contexto.Entry(productorModificado).State = EntityState.Modified;
                    contexto.SaveChanges();
                    flag = true;
                }
                return new JsonResult(flag);
            }
        }

        [HttpDelete]
        public JsonResult DeleteProductorDTO([FromBody] string correo)
        {
            bool flag = false;
            using (RMContext contexto = new RMContext())
            {
                var productorExistente = contexto.ProductorDTO.SingleOrDefault(p => p.Correo == correo);

                if (productorExistente != null)
                {
                    contexto.Entry(productorExistente).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    contexto.ProductorDTO.Attach(productorExistente);
                    contexto.Entry(productorExistente).State = EntityState.Modified;
                    contexto.SaveChanges();
                    flag = true;
                }
                return new JsonResult(flag);
            }
        }
    }
}