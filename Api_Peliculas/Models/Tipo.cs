using System;
using System.Collections.Generic;

namespace Api_Peliculas.Models;

public partial class Tipo
{
    public int Codigo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<RelacionPeliculasTipo> RelacionPeliculasTipos { get; set; } = new List<RelacionPeliculasTipo>();

    public virtual ICollection<RelacionPersonasTipo> RelacionPersonasTipos { get; set; } = new List<RelacionPersonasTipo>();
}
