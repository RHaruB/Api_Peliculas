using System;
using System.Collections.Generic;

namespace Api_Peliculas.Models;

public partial class RelacionPeliculasTipo
{
    public int? CodigoPelicula { get; set; }

    public int? CodigoTipo { get; set; }

    public int Codigo { get; set; }

    public virtual Pelicula? CodigoPeliculaNavigation { get; set; }

    public virtual Tipo? CodigoTipoNavigation { get; set; }
}
