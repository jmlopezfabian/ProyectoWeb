using RescueMarket.Context;
using RescueMarket.DTO;
using RescueMarket.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RescueMarket.Controllers
{
    [Route("DTOClientes")]
    [ApiController]
    public class DTOClienteController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetClientes()
        {
            List<DTO_Cliente> clientes = new List<DTO_Cliente>();

            using(RMContext context = new RMContext())
            {
                var aux = context.Cliente;
                foreach (var item in aux)
                {
                    clientes.Add(new DTO_Cliente
                    {
                        Nombre_Usuario = item.Nombre_Usuario,
                        Nombre = item.Nombre
                    });
                }
            }
            return new JsonResult(clientes);
        }
        [HttpPost]
        public bool LoginMethod([FromBody] string admin, string contra)
        {
            bool comprobacion = false;
            using (RMContext context = new RMContext())
            {
                var existe = context.Cliente.SingleOrDefault(c=>c.Nombre_Usuario == admin && c.Contrasena == contra);
                if(existe != null)
                {
                    comprobacion = true;
                }
                return comprobacion;
            }
        }
    }
}
