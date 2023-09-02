namespace Api_Peliculas.ViewModels
{
    public class PeliculasVM
    {
        public int Id { set; get; }
        public string Nombre{ set; get; }
        public DateTime Fecha_Estreno { set; get; }
        public string Imagen { set; get; }
        public string Tiempo_Duracion { set; get; }
        public List<GenerosVM>? Generos { set; get; }

    }
}
