using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiHorarios.Data;
using WebApiHorarios.Model;

namespace WebApiHorarios.Repositories
{
    public class HorarioRepository : IHorarioRepository
    {
         
        private readonly ApplicationDbContext _db;
        public HorarioRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Horario> GetHorario(int negocio, DiaDeSemana diaSemana)
        {
          return await _db.Horarios.Where(x => x.DiaDeLaSemana == diaSemana && x.IdNegocio == negocio).FirstOrDefaultAsync();
        }


        public void Insert(Horario horario)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Horario horario)
        {
            throw new NotImplementedException();
        }



        public List<Horario> GetHorarios()
        {
            return _db.Horarios.ToList();
        }
    }
}
