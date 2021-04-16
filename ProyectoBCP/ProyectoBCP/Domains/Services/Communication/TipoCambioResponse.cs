using ProyectoBCP.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP.Domains.Services.Communication
{
    public class TipoCambioResponse : BaseResponse<TipoCambio>
    {
        public TipoCambioResponse(string message) : base(message)
        {
        }

        public TipoCambioResponse(TipoCambio resource) : base(resource)
        {
        }
    }
}
