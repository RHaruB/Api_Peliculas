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
    }
}
