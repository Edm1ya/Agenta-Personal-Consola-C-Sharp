using DiarioPersonal.AccesoDatos;
using DiarioPersonal.Modelos;

public class DiarioPersonalApp
{
    public Intefaz intefaz;
    public Registro? registro;
    public List<Registro> registros;
    public DiarioRepositorio diarioRepositorio;

    public DiarioPersonalApp()
    {
        intefaz = new Intefaz();
        registros = new List<Registro>();
        diarioRepositorio  = new DiarioRepositorio();
        diarioRepositorio.CrearBD();
    }
    
    public void Menu()
    {
        Console.Clear();
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
                    intefaz.Titulo();
                    AcercaDe();
                    break;

                case "1":
                    intefaz.Titulo();
                    intefaz.MenuDiario();
                    DiarioPersonal();
                    break;

                case "2":
                    Console.WriteLine("Saliendo del programa...");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("   Opcion No Valida");
                    break;
            }
            Console.ReadKey();
        } while (opcion != "2");
    }

    public void AcercaDe() //Menu Acerca De
    {
        string? opcion;
        do
        {
            intefaz.MenuAcercaDe();
            opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    Menu();
                    break;

                case "2":
                    Console.WriteLine("\nSaliendo del programa...");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("  Opcion No Valida");
                    break;
            }
            Console.ReadKey();
        } while (opcion != "2");
    }

    public void DiarioPersonal() // Menu del diario personal
    {
        string? opcion;
        do
        {
            opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    //Listar Registros
                    intefaz.Titulo();
                    DetalleDeRegistros();
                    break;

                case "2":
                    //Agregar Registro
                    intefaz.Titulo();
                    AgregarRegistro();
                    break;

                case "3":
                    //Eliminar Registro 
                    intefaz.Titulo();
                    EliminarRegistro();
                    break;

                case "4":
                    //Actualizar Registro
                    intefaz.Titulo();
                    ModificarRegistro();
                    break; 

                case "5":
                    //Filtrar Registros
                    intefaz.Titulo();
                    FiltarRegistros();
                    break;

                case "6":
                    Menu();
                    break;

                case "7":
                    Console.WriteLine("Saliendo del programa");
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

    private void ListarRegistros(List<Registro> registros)
    {
        Console.WriteLine("\nREGISTROS DEL DIARIO");
        if (registros.Count() != 0)
        {
            for (int i = 0; i < registros.Count(); i++)
            {
                Console.WriteLine($"[{i}] {registros[i]}\n");
            }
        }
        else
        {
            Console.WriteLine("No hay registros");
        }
    }

    private void DetalleDeRegistros()
    {
        ListarRegistros(diarioRepositorio.ListarRegistros());
        Console.WriteLine("Introduzca el indice del Registro que desea ver a detalle");
        Console.Write("> ");
        string? entrada = Console.ReadLine();
        if (int.TryParse(entrada, out int indice))
        {
            if (indice >= 0 && indice < diarioRepositorio.ListarRegistros().Count())
            {
                registros = diarioRepositorio.ListarRegistros();
                Console.Clear();
                intefaz.Titulo();
                Console.WriteLine("\n***************************************************");
                Console.WriteLine($"{registros[indice].Fecha.ToString("dd/MM/yyyy")}\n{registros[indice].Titulo}\n\n{registros[indice].Contenido}\n\nCategoria: {registros[indice].Categoria} \nEstado de Animo: {registros[indice].EstadoDeAnimo}");
            }
            else
            {
                Console.WriteLine("Indice Invalido");
            }
        }
        else
        {
            Console.WriteLine("Indice incorrecto");
        }
    }

    private void AgregarRegistro()
    {
        Console.WriteLine("\nAGREGAR ENTRADA AL DIARIO\n");
        Console.WriteLine("Fecha Formato [DD/MM/YYYY]: ");
        Console.Write("> ");

        if(!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
        {
            Console.WriteLine("Formato de fecha incorrecto");
            return;
        }

        Console.Write("Titulo: ");
        string? titulo = Console.ReadLine();

        Console.Write("Contenido: ");
        string? contenido = Console.ReadLine();

        Console.Write("Categoria: ");
        string? categoria = Console.ReadLine();

        Console.Write("Estado de animo: ");
        string? estado = Console.ReadLine();

        registro = new Registro(fecha.Date, titulo!, contenido!, categoria!, estado!);

        diarioRepositorio.Agregar(registro);
        Console.WriteLine("Registro agregado correctamente");
        Console.ReadKey();
    }

    private void EliminarRegistro()
    { 
        ListarRegistros(diarioRepositorio.ListarRegistros());
        Console.WriteLine("Ingrese el indice del registro que desea eliminar");
        Console.Write("> ");

        string? entrada = Console.ReadLine();
        if (int.TryParse(entrada, out int indice))
        {
            if(indice >= 0 && indice < diarioRepositorio.ListarRegistros().Count())
            {
                registros = diarioRepositorio.ListarRegistros();
                int indiceBD = diarioRepositorio.ObtenerId(registros[indice]);
                diarioRepositorio.Borrar(indiceBD);

                Console.WriteLine("Registro borrado exitosamente");
            }else
            {
                Console.WriteLine("Indice Invalido");
            }
        }
        else
        {
            Console.WriteLine("Indice incorrecto");
        }
    }

    private void ModificarRegistro()
    {
        ListarRegistros(diarioRepositorio.ListarRegistros());
        Console.WriteLine("Ingrese el indice que desea actualizar");
        Console.Write("> ");
        
        if(int.TryParse(Console.ReadLine(), out int indice))
            {
                if (indice >= 0 && indice < diarioRepositorio.ListarRegistros().Count())
                {
                registros = diarioRepositorio.ListarRegistros();
                int indiceBD = diarioRepositorio.ObtenerId(registros[indice]);

                    Console.WriteLine("Fecha Formato [DD/MM/YYYY]: ");
                    Console.Write("> ");

                    if(!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
                    {
                        Console.WriteLine("Formato de fecha incorrecto");
                        return;
                    }

                    Console.Write("Titulo: ");
                    string? titulo = Console.ReadLine();

                    Console.Write("Contenido: ");
                    string? contenido = Console.ReadLine();

                    Console.Write("Categoria: ");
                    string? categoria = Console.ReadLine();

                    Console.Write("Estado de animo: ");
                    string? estado = Console.ReadLine();

                    registro = new Registro(fecha.Date, titulo!, contenido!, categoria!, estado!);
                    diarioRepositorio.Editar(registro, indiceBD);

                }else
                {
                    Console.WriteLine("Indice invalido");
                }
            }else
            {
                Console.WriteLine("Valor invalido");
            }
        Console.ReadKey();
    }

    private void FiltarRegistros()
    {
        ListarRegistros(diarioRepositorio.ListarRegistros());
        Console.WriteLine("Indicar fecha, categoria o estado de animo del registro que desea filtrar");
        Console.Write(">");
        string? criterioFiltrar = Console.ReadLine();
        if(criterioFiltrar != "") 
        { 
            registros = diarioRepositorio.ListarRegistros();
            var registrosFiltrados = registros
            .Where(r => r.Fecha.ToString("dd-MM-yyyy").Contains(criterioFiltrar!) ||
                r.Categoria.ToLower().Contains(criterioFiltrar!) ||
                r.EstadoDeAnimo.ToLower().Contains(criterioFiltrar!))
            .ToList();
            if (registrosFiltrados.Count() != 0)
            {
                ListarRegistros(registrosFiltrados);
                return;
            }
        }
        
        Console.WriteLine("No hay registros con esas caracteristicas");
    }
    
}
    