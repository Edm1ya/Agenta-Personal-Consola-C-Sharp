using DiarioPersonal.AccesoDatos;
using DiarioPersonal.Modelos;
using DiarioPersonal.Servicios;

public class Program
{
    private static void Main(string[] args)
    {
        Intefaz intefaz = new Intefaz();
        Diario diario = new Diario();
        Registro registro;
        List<Registro> registros = new List<Registro>();
        DiarioServicio diarioServicio = new DiarioServicio();
        int indice;
        DiarioRepositorio diarioRepositorio = new DiarioRepositorio();
        diarioRepositorio.CrearBD();

        // alimenta a la clase Diario con la informacion de la base de datos
        diarioServicio.ActualizarRegistros();
        
        Menu();

        void Menu()
        {
            string? opcion;
            do
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.Clear();
                intefaz.Titulo();
                intefaz.MenuPrincipal();
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "0":
                        Console.Clear();
                        intefaz.Titulo();
                        AcercaDe();
                        break;

                    case "1":
                        Console.Clear();
                        intefaz.Titulo();
                        intefaz.MenuDiario();
                        DiarioPersonal();
                        break;


                    case "2":
                        Console.WriteLine("Saliendo del programa");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("   Opcion No Valida");
                        break;
                }
                Console.ReadKey();
            } while (opcion != "2");
        }

        void AcercaDe()
        {
            string? opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════════════════════╗\r\n" +
                    "   Este es el proyecto final de la materia \n   Laboratorio Lenguaje de programacion I\n "+
                    "  Maestra: Betsabe Martinez \n   Seccion: 10\n\n   CREADORES\n "+
                    "  Edward Emilio Minaya Riva    100434130\n "+
                    "  Miguel Angel Sosa Paulino    100615597\n "+
                    "  Glimmer Méndez López         100193595\r\n " +
                    "╚══════════════════════════════════════════════╝");
                Console.WriteLine("\n  ► 1. - Volver Atras\n  ► 2. - Salir");
                Console.Write("\n  Digite una opcion: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Menu();
                        break;

                    case "2":
                        Console.WriteLine("\nSaliendo del programa");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("  Opcion No Valida");
                        break;
                }
                Console.ReadKey();
            } while (opcion != "2");
        }

        // Opciones del diario personal
        void DiarioPersonal()
        {
            string? opcion;
            do
            {
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        intefaz.Titulo();
                        registros = diarioServicio.ListarRegistros();
                        intefaz.ListarRegistros(registros);

                        break;

                    case "2":
                        intefaz.Titulo();
                        registro = intefaz.AgregarRegistro();
                        if (registro != null)
                        {
                            diarioServicio.AgregarRegistro(registro);
                        }
                        break;

                    case "3":
                        intefaz.Titulo();
                        registros = diarioServicio.ListarRegistros();
                        intefaz.ListarRegistros(registros);
                        indice = intefaz.EliminarRegistro(diarioServicio.ListarRegistros().Count);
                        if(indice != -2)
                        { 
                            diarioServicio.BorrarRegistro(indice);
                            Console.WriteLine("Registror Borrado");
                        }
                        break;

                    case "4":
                        intefaz.Titulo();
                        Console.WriteLine("Lista de registros");
                        registros = diarioServicio.ListarRegistros();
                        intefaz.ListarRegistros(registros);
                        Console.WriteLine("Modificar Registro\n");
                        indice = intefaz.EliminarRegistro(diarioServicio.ListarRegistros().Count);
                        
                        if (indice != -2)
                        {
                            registro = intefaz.AgregarRegistro();
                            if(registro != null)
                            {
                                diarioServicio.ModificarRegistro(registro, indice);
                                Console.WriteLine("El Registro a sido modificado");
                            }
                        }
                        break; 

                    case "5":
                        intefaz.Titulo();
                        Console.WriteLine("Filtrar Registro\n");
                        DateTime fechaAFiltar = intefaz.ModificarRegistro();
                        registros = diarioServicio.FiltarRegistros(fechaAFiltar);
                        intefaz.ListarRegistros(registros);
                        break;

                    case "6":
                        Menu();
                        break;

                    case "7":
                        Console.WriteLine("Saliendo del programa");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("   Opcion No Valida");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
                intefaz.Titulo();
                intefaz.MenuDiario();
            } while (opcion != "7");
        }
    }
}