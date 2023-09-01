using Api_Peliculas.Models;
using Api_Peliculas.ViewModels;

namespace Api_Peliculas.Service
{
    public class NetflixService : INetflixService
    {
        NetflixContext _context;
        public NetflixService(NetflixContext context)
        {
            _context = context;
        }

        public Response RegistrarGeneros(string generos)
        {
            Response response = new Response();
            try
            {
                var existe = _context.Tipos.Where(x => x.Descripcion == generos).Any();
                bool registrado = false;
                if (!existe)
                {
                    using (var context = _context.Database.BeginTransaction())
                    {
                        try
                        {
                            Tipo genero = new Tipo
                            {
                                Descripcion = generos
                            };
                            _context.Tipos.Add(genero);
                            _context.SaveChanges();

                            _context.SaveChanges();

                            context.Commit();

                            registrado = true;


                        }

                        catch (Exception ex)
                        {
                            context.Rollback();
                        }
                    }
                }
                response.Ejecutado = registrado;
                return response;
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
                return response;
            }

        }

        public Response RegistrarPersonas(PersonasVM persona)
        {
            Response response = new Response();

            try
            {
                var existe = _context.Personas.Where(x => x.Cedula == persona.Cedula).Any();
                bool registrado = false;
                if (!existe)
                {
                    using (var context = _context.Database.BeginTransaction())
                    {
                        try
                        {
                            Persona person = new Persona
                            {
                                Apellidos = persona.Apellidos,  
                                Cedula = persona.Cedula,
                                FechaNacimiento= persona.Fecha_Nacimiento,
                                Nombre = persona.Nombres
                            };
                            _context.Personas.Add(person);

                            _context.SaveChanges();
                            int codigo = _context.Personas.Where(x => x.Cedula == persona.Cedula).FirstOrDefault().CodigoPersona;

                            if(persona.Generos != null)
                            {
                                foreach (var item in persona.Generos)
                                {
                                    RelacionPersonasTipo relacion = new RelacionPersonasTipo
                                    {
                                        CodigoPersona = codigo,
                                        CodigoTipo = item.Id
                                    };
                                    _context.RelacionPersonasTipos.Add(relacion);
                                    _context.SaveChanges();
                                }
                            }                           

                            context.Commit();

                            registrado = true;
                        }
                        catch (Exception ex)
                        {
                            context.Rollback();
                        }
                    }
                }
                response.Ejecutado = registrado;
                return response;
            }
            catch (Exception ex)
            {
                response.Ejecutado = false;
                response.Mensaje = ex.Message;
            }

            return response;
        }
    }
}
