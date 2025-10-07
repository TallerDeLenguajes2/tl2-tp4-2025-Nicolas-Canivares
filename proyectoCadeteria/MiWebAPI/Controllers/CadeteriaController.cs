using EspacioCadete;
using EspacioCliente;
using EspacioPedido;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace EspacioCadeteria.Controllers
{

    [ApiController]
    [Route("api/{controller}")]
    public class CadeteriaController : ControllerBase
    {
        private Cadeteria cadeteria; //Cadeteria ya no es estatica
        private AccesoADatosCadeteria ADCadeteria;
        private AccesoADatosCadetes ADCadetes;
        private AccesoADatosPedidos ADPedidos;
        private Cadeteria _miCadeteria;

        //private AccesoADatos accesoADatos;

        public CadeteriaController()
        {
            ADCadeteria = new AccesoADatosCadeteria(); //NO OLVIDAR INICIALIZAR
            ADCadetes = new AccesoADatosCadetes();
            ADPedidos = new AccesoADatosPedidos();


            _miCadeteria = ADCadeteria.LeerArchivo();
            _miCadeteria.ListadoPedidos = ADPedidos.LeerArchivo();
        }

        [HttpGet]
        [Route("holamundo")]
        public IActionResult holaMundo()
        {
            return Ok("HOLA MUNDO");
        }

        [HttpGet]
        [Route("getcadeterias")]
        public IActionResult GetCadeterias()
        {
            var lista = ADCadeteria.LeerArchivo();
            return Ok(lista);
        }

        [HttpGet]
        [Route("getcadetes")]
        public IActionResult GetCadetes()
        {
            var lista = ADCadetes.LeerArchivo();
            return Ok(lista);
        }

        [HttpGet]
        [Route("getpedidos")]
        public IActionResult GetPedidos()
        {
            var lista = ADPedidos.LeerArchivo();
            return Ok(lista);
        }

        /* [HttpPost]
        [Route("postpedido")]
        public IActionResult PostPedido([FromBody] Pedido pedido)
        {
            int id = _miCadeteria.ListadoPedidos.Max(p => p.Nro) + 1;
            //var pedido = new Pedido pedidoNuevo(pedido.Nro, pedido.Obs, pedido.Cliente, pedido.Estado, pedido.Cadete);
            var pedidoNuevo = pedido;
            return Ok();
        } */
        
        [HttpPost]
        [Route("postpedido")]
        public IActionResult PostPedido(Pedido pedido)
        {

            int id = _miCadeteria.ListadoPedidos.Max(p => p.Nro) + 1;
            pedido.Nro = id;
            _miCadeteria.DarDeAltaPedido(pedido);
            ADCadeteria.GuardarArchivo(_miCadeteria);
            ADCadetes.GuardarArchivo(_miCadeteria.ListadoCadetes);
            ADPedidos.GuardarArchivo(_miCadeteria.ListadoPedidos);
            //_miCadeteria.ListadoPedidos.Add(pedido);
            //var pedido = new Pedido pedidoNuevo(pedido.Nro, pedido.Obs, pedido.Cliente, pedido.Estado, pedido.Cadete);
            //var pedidoNuevo = pedido;
            return Created();
        }

    }


}