using Microsoft.AspNetCore.Mvc;
using ProyectoBCP.Domains.Models;
using ProyectoBCP.Domains.Services;
using ProyectoBCP.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CambioController : Controller
    {

        private readonly ICambioService _cambioService;
        public CambioController(ICambioService cambioService)
        {
            _cambioService = cambioService;
        }

        [HttpGet]
        public async Task<IEnumerable<Cambio>> GetAllAsync()
        {
            var cambios = await _cambioService.ListAsync();
            return cambios;
        }
        [HttpGet("BuscarTipoCambio/Fecha/{fecha}/TipoTransa/{tipo}/Origen/{origen}/Destino/{destino}")]
        public async Task<IActionResult> GetOneCambioAsync(string fecha,string tipo,string origen,string destino)
        {
            var cambio = await _cambioService.FindByFechaAndTipoTransaccionAndMonedaOrigenAndMonedaDestino(fecha,tipo,origen,destino);
            return Ok(cambio.Resource);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Cambio resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetMessages());
            }
            
            var result = await _cambioService.SaveAsync(resource);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }
        [HttpPost("CalcularTipoCambio")]
        public async Task<IActionResult> CalcularAsync([FromBody] TipoCambio resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetMessages());
            }

            var result = await _cambioService.Calcular(resource.FechaTipoCambio,resource.TipoTransaccion,resource.MonedaOrigen,resource.MonedaDestino,resource.Monto);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }
    }
}
