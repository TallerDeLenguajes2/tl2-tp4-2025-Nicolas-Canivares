using Microsoft.AspNetCore.Mvc;

namespace EspacioCadeteria.Controllers
{

    [ApiController]
    [Route("api/{controller}")]
    public class PedidosController : ControllerBase
    {
        public PedidosController()
        {
        }

        [HttpGet]
        [Route("holamundo")]
        public IActionResult holaMundo()
        {
            return Ok("HOLA MUNDO");
        }


    }


}