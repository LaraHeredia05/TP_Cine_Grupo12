using Microsoft.AspNetCore.Mvc;
using Tpi_Cine_Grupo12.Interface.Contracts;
using Tpi_Cine_Grupo12.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tpi_Cine_Grupo12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CineController : ControllerBase
    {
        private readonly ICineRepository repository;

        public CineController(ICineRepository _repository) { repository = _repository; }

        [HttpGet("generos")]
        public async Task<IActionResult> GetGeneros()
        {
            try
            {
                List<Generos> generos = await repository.GetGeneros();

                if (generos.Count > 0)
                {
                    return Ok(generos);
                }
                else
                {
                    return Ok("No hay géneros disponibles.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno: " + ex.Message);
            }

        }

        [HttpGet("usuario")]
        public async Task<IActionResult> GetClientes([FromQuery] string usuario, string contraseña)
        {
            try
            {
                List<Clientes> clientes = await repository.GetClientes(usuario, contraseña);

                if (clientes.Count > 0)
                {
                    return Ok(clientes);
                }
                else
                {
                    return Ok("No existen Clientes");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno: " + ex.Message);
            }

        }

        [HttpGet("butacasdisponibles")]
        public async Task<IActionResult> GetButacasDisponibles(int ticket)
        {
            try
            {
                List<Butacas> butacas = await repository.GetButacasDisponibles(ticket);

                if (butacas.Count > 0)
                {
                    return Ok(butacas);
                }
                else
                {
                    return Ok("No hay Butacas disponibles");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno: " + ex.Message);
            }

        }

        [HttpPost("crearusuario")]
        public async Task<IActionResult> PostCliente([FromQuery] string nombre, string apellido, string email, string telefono, string usuario, string contraseña)
        {
            try
            {
                if (await repository.PostCliente(nombre, apellido, email, telefono, usuario, contraseña))
                {
                    return Ok("Se creó exitosamente el usuario");
                }
                else
                {
                    return StatusCode(400, "No pudo registrarse el usuario...");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno: " + ex.Message);
            }
        }

        [HttpDelete("cancelarcompra")]
        public async Task<IActionResult> CancelarCompra([FromQuery] int comprobante)
        {
            try
            {
                if (await repository.CancelarCompra(comprobante))
                {
                    return Ok($"La compra de id {comprobante} se canceló exitosamente");
                }
                else
                {
                    return NotFound("No se encontró un comprobante con ese ID");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno: " + ex.Message);
            }
        }

    }
}
