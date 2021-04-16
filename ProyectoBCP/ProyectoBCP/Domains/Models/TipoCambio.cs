using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP.Domains.Models
{
    public class TipoCambio
    {
        public string FechaTipoCambio { get; set; }
        public string TipoTransaccion { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }

        public double MontoCambio { get; set; }
        public double Monto { get; set; }
        public double MontoTipoCambio { get; set; }
    }
}
