using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using WebApiHorarios.Model;
using WebApiHorarios.Models;
using WebApiHorarios.Models.CalendarHelper;
using WebApiHorarios.Repositories;

namespace WebApiHorarios.Controllers
{
    [Produces("application/json")]
    [Route("api/{controller}")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private readonly ILogger<HorarioController> _logger;
        private readonly IHorarioRepository _repository;
        public HorarioController(ILogger<HorarioController> logger, IHorarioRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
 
        [HttpGet("{negocio}/{anio}/{mes}/{dia}")]
        public async Task<IActionResult> GetHorarioPorFecha(int negocio, int anio, int mes, int dia)
        {
            try
            {
                DateTime fecha = new DateTime(anio, mes, dia);
                var diaSemana = CalendarHelper.CalcularDiaDeLaSemana(fecha);
                Horario horarioResult = await _repository.GetHorario(negocio, diaSemana);
                if (horarioResult == null)
                          return NotFound();
                
                var horaAperturaFormateada = String.Format("{0:t}", horarioResult.HorarioApertura); 
                var horaCierreFormateada = String.Format("{0:t}", horarioResult.HorarioCierre);

                var horarioResponse = new { horarioApertura = horaAperturaFormateada, horarioCierre = horaCierreFormateada };
                return Ok(horarioResponse);
            }
           
            catch (Exception exception)
            {
                _logger.LogInformation($"Fallo en la busqueda del negocio: { negocio } -- Problema: {exception.Message}");
                return BadRequest($"Problema al intentar realizar el horario del negocio: {negocio}");
            }
        }


    }

}