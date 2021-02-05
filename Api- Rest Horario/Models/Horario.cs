using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiHorarios.Model
{
    public class Horario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int IdNegocio { get; set; }
 
        public DiaDeSemana DiaDeLaSemana { get; set; }
        public TimeSpan HorarioApertura { get; set; }
        public TimeSpan HorarioCierre { get; set; }

    }
    public enum DiaDeSemana
    {
        Lunes = 1,
        Martes = 2,
        Miercoles = 3,
        Jueves = 4,
        Viernes = 5,
        Sabado = 6,
        Domingo = 7
    }
}
