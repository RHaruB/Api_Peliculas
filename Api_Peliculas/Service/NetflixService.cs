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

        public List<GenerosVM> GetAllGeneros()
        {
            List<GenerosVM> Lista = new List<GenerosVM>();

            var consulta = _context.Tipos.ToList();
            foreach (var item in consulta)
            {
                GenerosVM genero = new GenerosVM
                {
                    Descripcion = item.Descripcion,
                    Id = item.Codigo
                };
                Lista.Add(genero);
            }

            return Lista;
        }

        public List<PersonasVM> GetAllPersonas()
        {
            List<PersonasVM> lista = new List<PersonasVM>();

            var consulta = _context.Personas.ToList();

            foreach (var item in consulta)
            {
                PersonasVM persona = new PersonasVM
                {
                    Apellidos = item.Apellidos,
                    Cedula = item.Cedula,
                    Codigo = item.CodigoPersona,
                    Fecha_Nacimiento = (DateTime)item.FechaNacimiento,
                    Nombres = item.Nombre
                };
                lista.Add(persona); 
            }

            return lista;
        }

        public List<PeliculasVM> GetAllPeliculas()
        {
            List<PeliculasVM> lista = new List<PeliculasVM>();

            var consulta = _context.Peliculas.ToList();

            foreach (var item in consulta)
            {
                PeliculasVM pelicula = new PeliculasVM
                {
                    Fecha_Estreno = (DateTime)item.FechaEstreno,
                    Id = item.CodigoPelicula,
                    Imagen = item.Imagen,
                    Nombre = item.NombrePelicula,
                    Tiempo_Duracion = item.TiempoDuracion
                };
                lista.Add(pelicula);
            }
            return lista;
        }

        public Response RegistrarPeliculas(PeliculasVM pelicula)
        {
            Response response = new Response();

            try
            {
                var existe = _context.Peliculas.Where(x => x.NombrePelicula == pelicula.Nombre).Any();
                bool registrado = false;
                if (!existe)
                {
                    using (var context = _context.Database.BeginTransaction())
                    {
                        try
                        {
                            Pelicula peliculaBD = new Pelicula
                            {
                                FechaEstreno = pelicula.Fecha_Estreno,
                                NombrePelicula= pelicula.Nombre,
                                Imagen= pelicula.Imagen,
                                TiempoDuracion = pelicula.Tiempo_Duracion
                            };
                            _context.Peliculas.Add(peliculaBD);

                            _context.SaveChanges();
                            int codigo = _context.Peliculas.Where(x => x.NombrePelicula == pelicula.Nombre).FirstOrDefault().CodigoPelicula;

                            if (pelicula.Generos != null)
                            {
                                foreach (var item in pelicula.Generos)
                                {
                                    RelacionPeliculasTipo relacion = new RelacionPeliculasTipo
                                    {
                                        CodigoPelicula = codigo,
                                        CodigoTipo = item.Id
                                    };
                                    _context.RelacionPeliculasTipos.Add(relacion);
                                    _context.SaveChanges();
                                }
                            }

                            context.Commit();

                            registrado = true;
                        }
                        catch (Exception )
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
