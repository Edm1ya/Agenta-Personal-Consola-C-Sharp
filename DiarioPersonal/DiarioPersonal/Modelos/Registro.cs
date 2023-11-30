namespace DiarioPersonal.Modelos
{
    public class Registro
    {
        public DateTime Fecha { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string Categoria { get; set; }
        public string EstadoDeAnimo { get; set; }

        public Registro(DateTime fecha, string titulo, string contenido, string categoria, string estadodeanimo)
        {
            Fecha = fecha;
            Titulo = titulo;
            Contenido = contenido;
            Categoria = categoria;
            EstadoDeAnimo = estadodeanimo;
        }

        public override string ToString()
        {
            return $"{Fecha.ToString("dd-MM-yyyy")}, {Titulo}, {Contenido}, {Categoria}, {EstadoDeAnimo}";
        }
    }
}