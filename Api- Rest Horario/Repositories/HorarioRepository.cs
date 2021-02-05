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


        public void Insert(Horario user)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Horario user)
        {
            throw new NotImplementedException();
        }

        public HorarioRepository()
        {
            this.loadData();
        }

        private void loadData()
        {
            //_listHorarios.AddRange(new List<Horario>()
            //{
                //new Horario(){IdNegocio = 2,  DiaDeLaSemana = DiaDeSemana.Jueves , HorarioApertura=new TimeSpan(10,00,00),HorarioCierre=new TimeSpan(19,00,00)},
                //new Horario(){IdNegocio = 4,  DiaDeLaSemana = DiaDeSemana.Sabado , HorarioApertura=new TimeSpan(08,00,00),HorarioCierre=new TimeSpan(16,00,00)},
                //new Horario(){IdNegocio = 1,  DiaDeLaSemana = DiaDeSemana.Jueves , HorarioApertura=new TimeSpan(10,00,00),HorarioCierre=new TimeSpan(19,00,00)},
                //new Horario(){IdNegocio = 2,  DiaDeLaSemana = DiaDeSemana.Martes , HorarioApertura=new TimeSpan(9,00,00),HorarioCierre=new TimeSpan(20,00,00)},
                //new Horario(){IdNegocio = 3,  DiaDeLaSemana = DiaDeSemana.Miercoles , HorarioApertura=new TimeSpan(9,00,00),HorarioCierre=new TimeSpan(20,00,00)},
                //new Horario(){IdNegocio = 5,  DiaDeLaSemana = DiaDeSemana.Lunes , HorarioApertura=new TimeSpan(8,00,00),HorarioCierre=new TimeSpan(19,00,00)},
                //new Horario(){IdNegocio = 5,  DiaDeLaSemana = DiaDeSemana.Miercoles , HorarioApertura=new TimeSpan(8,00,00),HorarioCierre=new TimeSpan(19,00,00)},
                //new Horario(){IdNegocio = 5,  DiaDeLaSemana = DiaDeSemana.Sabado , HorarioApertura=new TimeSpan(8,00,00),HorarioCierre=new TimeSpan(13,00,00)},
            //});
        }
        //public IEnumerable<Horario> GetHorarios()
        //{
        //    return _listHorarios;
        //}

 

        public List<Horario> GetHorarios()
        {
            return _db.Horarios.ToList();
        }
    }
}
