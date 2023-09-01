using System;
using System.Collections.Generic;

namespace Api_Peliculas.Models;

public partial class Persona
{
    public int CodigoPersona { get; set; }

    public string? Apellidos { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Cedula { get; set; }

    public virtual ICollection<RelacionPersonasTipo> RelacionPersonasTipos { get; set; } = new List<RelacionPersonasTipo>();
}
