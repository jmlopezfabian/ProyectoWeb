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
                var aux = context.ClientesDTO;
                foreach (var item in aux)
                {
                    clientes.Add(new DTO_Cliente
                    {
                        Correo = item.Correo,
                        Nombre_Usuario = item.Nombre_Usuario,
                        Nombre = item.Nombre
                    });
                }
            }
            return new JsonResult(clientes);
        }
    }
}
