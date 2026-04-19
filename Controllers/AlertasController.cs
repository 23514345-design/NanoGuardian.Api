using Microsoft.AspNetCore.Mvc;
using NanoGuardian.Api.Models;

namespace NanoGuardian.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertasController : ControllerBase
    {
        private static List<Alerta> _alertas = new List<Alerta>
        {
            new Alerta { Paciente = "Usuario 1", FuerzaImpactoG = 0, Estado = "Sin obstáculo" }
        };

        [HttpGet]
        public IActionResult ObtenerAlertas()
        {
            return Ok(_alertas);
        }

        [HttpPost]
        public IActionResult RecibirAlerta([FromBody] Alerta nuevaAlerta)
        {
            if (string.IsNullOrEmpty(nuevaAlerta.Paciente))
                return BadRequest("El nombre del paciente es obligatorio.");

            _alertas.Add(nuevaAlerta);
            Console.WriteLine($"🚨 Obstáculo detectado: {nuevaAlerta.FuerzaImpactoG}cm - {nuevaAlerta.Estado}");

            return Ok(new { mensaje = "Alerta procesada con éxito", codigo = 200 });
        }
    }
}