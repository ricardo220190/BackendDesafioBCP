using Microsoft.EntityFrameworkCore;
using ProyectoBCP.Domains.Models;
using ProyectoBCP.Domains.Persistance.Context;
using ProyectoBCP.Domains.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP.Persistance.Repositories
{
    public class CambioRepository : BaseRepository,ICambioRepository
    {
        public CambioRepository(AppDbContext context) : base(context)
        {
        }

        //Agrega un registro en la base de datos
        public async Task AddAsync(Cambio cambio)
        {
            await _context.cambios.AddAsync(cambio);
        }
        //Lista todos los registros
        public async Task<IEnumerable<Cambio>> ListAsync()
        {
            return await _context.cambios.ToListAsync();
        }
        //Consultar un registro 
        public async Task<Cambio> FindByFechaAndTipoTransaccionAndMonedaOrigenAndMonedaDestino(string fecha,string tipotransaccion,string monedaOrigen,string monedaDestino)
        {
            return await _context.cambios.FirstOrDefaultAsync(c => c.FechaTipoCambio == fecha && c.TipoTransaccion == tipotransaccion && c.MonedaOrigen == monedaOrigen && c.MonedaDestino == monedaDestino);
        }
       
       
    }
}
