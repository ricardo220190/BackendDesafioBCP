using ProyectoBCP.Domains.Models;
using ProyectoBCP.Domains.Repositories;
using ProyectoBCP.Domains.Services;
using ProyectoBCP.Domains.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoBCP.Services
{
    public class CambioService: ICambioService
    {
        private readonly ICambioRepository _cambioRepository;
        private readonly IUnitOfWork _unitOfWork;
        //Metodo para inicializar 
        public CambioService(ICambioRepository cambioRepository, IUnitOfWork unitOfWork)
        {
            _cambioRepository = cambioRepository;
            _unitOfWork = unitOfWork;
        }
        //Funcion que calcula el tipo de cambio
        public async Task<TipoCambioResponse> Calcular(string fecha, string tipotransaccion, string monedaOrigen, string monedaDestino, double monto)
        {
            var MontoDevuelto = 0.0;
            var existingCambio = await _cambioRepository.FindByFechaAndTipoTransaccionAndMonedaOrigenAndMonedaDestino( fecha,  tipotransaccion,  monedaOrigen,  monedaDestino);
            if (existingCambio.TipoTransaccion == "Venta")
            {
                MontoDevuelto =  monto / existingCambio.MontoCambio ;
                MontoDevuelto = Math.Round(MontoDevuelto,2);
            }
            else if(existingCambio.TipoTransaccion == "Compra")
            {
                MontoDevuelto = existingCambio.MontoCambio * monto;
                MontoDevuelto = Math.Round(MontoDevuelto,2);
            }
            
            TipoCambio tipoCambio = new TipoCambio();
            tipoCambio.FechaTipoCambio = existingCambio.FechaTipoCambio;
            tipoCambio.TipoTransaccion = existingCambio.TipoTransaccion;
            tipoCambio.MonedaOrigen = existingCambio.MonedaOrigen;
            tipoCambio.MonedaDestino = existingCambio.MonedaDestino;
            tipoCambio.MontoCambio = Math.Round(existingCambio.MontoCambio,4);    
            tipoCambio.Monto = monto;
            tipoCambio.MontoTipoCambio = MontoDevuelto;
            return new TipoCambioResponse(tipoCambio);
        }

        //Consulta un registro
        public async Task<CambioResponse> FindByFechaAndTipoTransaccionAndMonedaOrigenAndMonedaDestino(string fecha, string tipotransaccion, string monedaOrigen, string monedaDestino)
        {
            var existingCambio = await _cambioRepository.FindByFechaAndTipoTransaccionAndMonedaOrigenAndMonedaDestino(fecha, tipotransaccion, monedaOrigen, monedaDestino);
            if (existingCambio == null)
                return new CambioResponse("Tipo de cambio no encontrado");
            return new CambioResponse(existingCambio);
        }
        //Listar todos los registros
        public async Task<IEnumerable<Cambio>> ListAsync()
        {
            return await _cambioRepository.ListAsync();
        }
        //Para guardar nuevos registros 
        public async Task<CambioResponse> SaveAsync(Cambio cambio)
        {
           
            try
            {
                await _cambioRepository.AddAsync(cambio);
                await _unitOfWork.CompleteAsync();

                return new CambioResponse(cambio);
            }
            catch (Exception ex)
            {
                return new CambioResponse($"Ha ocurrido un error mientras se actualizaba el tipo de cambio: { ex.Message }");
            }
        }

        
    }
}
