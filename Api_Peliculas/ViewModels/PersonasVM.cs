namespace Api_Peliculas.ViewModels
{
    public class PersonasVM
    {
        public int Codigo {set;get;}
        public string Apellidos { set;get;}
        public string Nombres { set;get;}
        public string Cedula { set;get;}
        public DateTime Fecha_Nacimiento { set; get;}

        public List<GenerosVM>? Generos { set; get;}
    }
}