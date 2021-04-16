using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProyectoBCP.Domains.Models;
using ProyectoBCP.Domains.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP.DataContext.Data
{
    public static class DbInitializer
    {
        public static void Initializer(IServiceProvider serviceProvider)
        {
            using (var _context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (_context.cambios.Any())
                {
                    return;
                }
                _context.cambios.AddRange(
                        new Cambio { FechaTipoCambio = "15-04-2021",TipoTransaccion = "Venta", MonedaOrigen = "Soles", MonedaDestino = "Dolar", MontoCambio = 3.631 },
                        new Cambio { FechaTipoCambio = "15-04-2021",TipoTransaccion = "Compra", MonedaOrigen = "Dolar", MonedaDestino = "Soles", MontoCambio = 3.626 },
                        new Cambio { FechaTipoCambio = "15-04-2021", TipoTransaccion = "Venta", MonedaOrigen = "Dolar", MonedaDestino = "Euro", MontoCambio = 1.1972 },
                        new Cambio { FechaTipoCambio = "15-04-2021", TipoTransaccion = "Compra", MonedaOrigen = "Euro", MonedaDestino = "Dolar", MontoCambio = 1.1967 }
                    ) ;
                _context.SaveChanges();
            }
        }
    }
}
