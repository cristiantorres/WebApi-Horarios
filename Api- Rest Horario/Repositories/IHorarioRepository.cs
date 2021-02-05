using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiHorarios.Model;

namespace WebApiHorarios.Repositories
{
   public interface IHorarioRepository
    {
        
        Task<Horario>  GetHorario(int negocio, DiaDeSemana diaSemana);
        List<Horario> GetHorarios();

        void Insert(Horario user);
        void Update(Horario user);
        void Save();
    }
}
