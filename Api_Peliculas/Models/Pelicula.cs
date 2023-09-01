using System;
using System.Collections.Generic;

namespace Api_Peliculas.Models;

public partial class Pelicula
{
    public int CodigoPelicula { get; set; }

    public string? NombrePelicula { get; set; }

    public DateTime? FechaEstreno { get; set; }

    public string? Imagen { get; set; }

    public string? TiempoDuracion { get; set; }

    public virtual ICollection<RelacionPeliculasTipo> RelacionPeliculasTipos { get; set; } = new List<RelacionPeliculasTipo>();
}
