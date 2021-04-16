using ProyectoBCP.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP.Domains.Services.Communication
{
    public class CambioResponse : BaseResponse<Cambio>
    {
        public CambioResponse(string message) : base(message)
        {
        }

        public CambioResponse(Cambio resource) : base(resource)
        {
        }
    }
}
