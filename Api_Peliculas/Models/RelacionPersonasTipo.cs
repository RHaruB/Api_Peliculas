using System;
using System.Collections.Generic;

namespace Api_Peliculas.Models;

public partial class RelacionPersonasTipo
{
    public int? CodigoPersona { get; set; }

    public int? CodigoTipo { get; set; }

    public virtual Persona? CodigoPersonaNavigation { get; set; }

    public virtual Tipo? CodigoTipoNavigation { get; set; }
}
