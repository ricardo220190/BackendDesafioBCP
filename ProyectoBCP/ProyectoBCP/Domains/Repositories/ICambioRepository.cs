using ProyectoBCP.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP.Domains.Repositories
{
    public interface ICambioRepository
    {
        Task<IEnumerable<Cambio>> ListAsync();
        Task AddAsync(Cambio cambio);

        Task<Cambio> FindByFechaAndTipoTransaccionAndMonedaOrigenAndMonedaDestino(string fecha, string tipotransaccion, string monedaOrigen, string monedaDestino);

    }
}
