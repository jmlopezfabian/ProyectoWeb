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
        public JsonResult GetproductorDTO([FromBody] string correo)
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

        [HttpPost]
        public JsonResult PostProductorDTO([FromBody] DTO_Productor nuevo_productor)
        {
            bool flag = false;
            DTO_Productor productor = new DTO_Productor();

            using (RMContext contexto = new RMContext())
            {
                var existe = contexto.ProductorDTO.SingleOrDefault(i => i.Correo == nuevo_productor.Correo);

                bool flag = false;
                if (existe == null)
                {
                    productor.Correo = existe.Correo;
                    productor.Nombre_Usuario = existe.Nombre_Usuario;
                    productor.Nombre = existe.Nombre;
                    productor.Telefono = existe.Telefono;
                    productor.Num_ext = existe.Num_ext;
                    productor.Calle = existe.Calle;
                    productor.Ciudad = existe.Ciudad;
                    productor.Codigo_Postal = existe.Codigo_Postal;
                    flag = true;
                }
            }

            return new JsonResult(productor);
        }

        [HttpPatch("{correo}")]
        public IActionResult PatchProductorDTO(string correo, [FromBody] DTO_Productor productorModificado)
        {
            using (RMContext contexto = new RMContext())
            {
                var productorExistente = contexto.ProductorDTO.SingleOrDefault(p => p.Correo == correo);

                if (productorExistente == null)
                {
                    productorExistente.Nombre_Usuario = productorModificado.Nombre_Usuario;

                    productorExistente.Nombre = productorModificado.Nombre;

                    productorExistente.Telefono = productorModificado.Telefono;

                    productorExistente.Num_ext = productorModificado.Num_ext;

                    productorExistente.Calle = productorModificado.Calle;

                    productorExistente.Ciudad = productorModificado.Ciudad;

                    productorExistente.Codigo_Postal = productorModificado.Codigo_Postal;

                    // Guardar los cambios en la base de datos
                    contexto.SaveChanges();
                    flag = true;
                }
                return new JsonResult(productorExistente);
            }
        }

        [HttpDelete]
        public JsonResult DeleteProductorDTO([FromBody] DTO_Productor productor)
        {
            bool flag = false;
            using (RMContext context = new RMContext())
            {
                var existe = context.Productores.SingleOrDefault(a => a.Correo == productor.Correo);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Productores.Attach(productores);
                    context.Entry(productores).State = EntityState.Deleted;
                    context.SaveChanges();
                    flag = true;
                }
            }
            return new JsonResult(flag);
        }


    }
}