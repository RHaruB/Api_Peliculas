namespace Api_Peliculas.ViewModels
{
    public class Response
    {
        public string? Codigo_Error { set; get; }
        public string? Mensaje { get; set;}
        public bool? Ejecutado { get; set;} 
        public object? Data { get; set;}
    }
}
