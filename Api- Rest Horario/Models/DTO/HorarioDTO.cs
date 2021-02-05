using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiHorarios.Models
{
    public class HorarioDTO
    {
 
        public TimeSpan HoraApertura { get; set; }
        public TimeSpan HoraCierre { get; set; }
        public string Negocio { get; set; }
    }
}
