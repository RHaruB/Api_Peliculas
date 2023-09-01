using Api_Peliculas.ViewModels;

namespace Api_Peliculas.Service
{
    public interface INetflixService
    {
        public Response RegistrarGeneros(string generos);
        public Response RegistrarPersonas(PersonasVM persona);
    }
}
