using ProyectoBCP.Domains.Models;
using ProyectoBCP.Domains.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP.Domains.Services
{
    public interface ICambioService
    {
        Task<IEnumerable<Cambio>> ListAsync();
        Task<CambioResponse> SaveAsync(Cambio cambio);
        Task<CambioResponse> FindByFechaAndTipoTransaccionAndMonedaOrigenAndMonedaDestino(string fecha, string tipotransaccion, string monedaOrigen, string monedaDestino);
        Task<TipoCambioResponse> Calcular(string fecha, string tipotransaccion, string monedaOrigen, string monedaDestino, double monto);
    }
}
