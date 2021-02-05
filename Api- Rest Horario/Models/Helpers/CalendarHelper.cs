using System;
using WebApiHorarios.Model;

namespace WebApiHorarios.Models.CalendarHelper
{
    public static class CalendarHelper
    {
        /// <summary>
        /// Retorna el dia de la semana para una fecha en particular
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static DiaDeSemana CalcularDiaDeLaSemana(DateTime fecha)
        {

            var diaSemana = fecha.DayOfWeek.ToString();
            switch (diaSemana)
            {
                case "Monday":
                    return DiaDeSemana.Lunes;

                case "Tuesday":
                    return DiaDeSemana.Martes;

                case "Wednesday":
                    return DiaDeSemana.Miercoles;

                case "Thursday":
                    return DiaDeSemana.Jueves;

                case "Saturday":
                    return DiaDeSemana.Sabado;
                case "Sunday":
                    return DiaDeSemana.Domingo;

                default:
                    return DiaDeSemana.Viernes;

            };

        }
    }
}
