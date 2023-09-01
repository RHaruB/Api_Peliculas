namespace Api_Peliculas.ViewModels
{
    public class PersonasVM
    {
        public int Codigo {set;get;}
        public string Apellidos { set;get;}
        public string Nombres { set;get;}
        public DateTime Fecha_Nacimiento { set; get;}

        public List<Generos>? Generos { set; get;}
    }
}