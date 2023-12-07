
namespace DiarioPersonal.Utilidades
{
    public class Validaciones
    {
        public readonly int cantTitulo;
        public readonly int cantContenido;
        public Intefaz intefaz = new Intefaz();

        public Validaciones()
        {
            this.cantTitulo = 100; 
            this.cantContenido = 1000;
        }

        public DateTime ValidarFecha()
        {
            
            bool fechaValida = false;
            DateTime fecha;
            do
            {
                Console.WriteLine("Fecha Formato [DD/MM/YYYY]: ");
                Console.Write("> ");
                string? imputfecha = Console.ReadLine();

                if (imputfecha.ToLower() == "x")
                {
                    fecha = DateTime.MinValue;
                    fechaValida = true;
                }
                else if (DateTime.TryParse(imputfecha, out fecha))
                {
                    fechaValida = true;
                }
                else
                {
                    Console.WriteLine("formato de fecha incorrecto");
                    Console.ReadKey();
                    intefaz.Titulo();
                    Console.WriteLine("\nAGREGAR ENTRADA AL DIARIO\n");
                }
            } while (!fechaValida);

            return fecha;
        }

        public string ValidacionTitulo()
        {
            bool tituloValido = false;
            string titulo;
            do
            {
                Console.Write("Titulo: ");
                titulo = Console.ReadLine() ?? "";
                if (titulo.Count() <= cantTitulo)
                {
                    tituloValido= true;
                }
                else if (titulo.ToLower() == "x")
                {
                    titulo = String.Empty;
                    tituloValido = true;
                }
                else
                {
                    Console.WriteLine($"Excedio la cantidad de {cantTitulo}");
                    Console.ReadKey();
                    intefaz.Titulo();
                    Console.WriteLine("\nAGREGAR ENTRADA AL DIARIO\n");
                }

            } while (!tituloValido);

            return titulo;
            
        }

        public string ValidacionContenido()
        {
            bool contenidoValido = false;
            string contenido;
            do
            {
                Console.Write("Contenido: ");
                contenido = Console.ReadLine() ?? "";
                if (contenido.Count() <= cantTitulo)
                {
                    contenidoValido = true;
                }
                else if (contenido.ToLower() == "x")
                {
                    contenido = String.Empty;
                    contenidoValido = true;
                }
                else
                {
                    Console.WriteLine($"Excedio la cantidad de {cantContenido}");
                    Console.ReadKey();
                    intefaz.Titulo();
                    Console.WriteLine("\nAGREGAR ENTRADA AL DIARIO\n");
                }

            } while (!contenidoValido);

            return contenido;

        }
    }
}
