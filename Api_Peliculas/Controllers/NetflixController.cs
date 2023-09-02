using Api_Peliculas.Models;
using Api_Peliculas.Service;
using Api_Peliculas.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Peliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetflixController : ControllerBase
    {
        private readonly INetflixService _netflix;
        public NetflixController(INetflixService netflixService)
        {
            _netflix = netflixService;
        }
        [HttpPost("RegistroGeneros")]
        public IActionResult RegistroGeneros(string descripcion)
        {
            try
            {
                var result = _netflix.RegistrarGeneros(descripcion);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }

        }
        [HttpPost("RegistroPersonas")]
        public IActionResult RegistroPersonas(PersonasVM persona)
        {
            try
            {
                var result = _netflix.RegistrarPersonas(persona);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }

        }
        [HttpPost("RegistroPeliculas")]
        public IActionResult RegistroPeliculas(PeliculasVM peliculas)
        {
            try
            {
                var result = _netflix.RegistrarPeliculas(peliculas);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }

        }

        [HttpGet("GetAllGeneros")]
        public IActionResult GetAllGeneros()
        {
            var result = _netflix.GetAllGeneros();
            return new JsonResult(result);

        }

        [HttpGet("GetAllPersonas")]
        public IActionResult GetAllPersonas()
        {
            var result = _netflix.GetAllPersonas();
            return new JsonResult(result);
        }
        [HttpGet("GetAllPeliculas")]
        public IActionResult GetAllPeliculas()
        {
            var result = _netflix.GetAllPeliculas();
            return new JsonResult(result);
        }
    }
}
