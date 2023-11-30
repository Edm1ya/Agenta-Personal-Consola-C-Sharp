using DiarioPersonal.Modelos;
using DiarioPersonal.Servicios;
using DiarioPersonal.Utilidades;

public class Intefaz
{
    public void Titulo(){
        Console.Clear();
        Console.WriteLine(
        "╔═════════════════════════════════════════════════╗" +
        "\r\n                 DIARIO PERSONAL                  \r\n"+
        "╚═════════════════════════════════════════════════╝"
        );
    }

    public void MenuPrincipal(){
        Console.WriteLine();
        Console.WriteLine("\n\n▼▼|| Seleccione la opcion que desea EJECUTAR  ||▼▼");
        Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
        Console.WriteLine("" +
            "\n ► 0. - Acerca del proyecto" +         
            "\n\n ► 1. - Abrir Diario" +
            "\n ______________________________________" +
            "\n --------------------------------------" +
            "\n\n ► 2. - Salir\n");
        Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
        Console.Write("\n   Digite una opcion: ");
    }

    public void MenuDiario(){
        Console.WriteLine("\n\n▼▼|| MENU DE OPCIONES  ||▼▼");
        Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
        Console.WriteLine("" +
            "\n ► 1. - Listar Registros" +                   
            "\n ► 2. - Agregar Registros" +
            "\n ► 3. - Eliminar Registros" +
            "\n ► 4. - Modificar Registros" +
            "\n___________________________________________________" +
            "\n___________________________________________________" +
            "\n\n ► 6. - Volver Atras" +
            "\n ► 7. - Salir\n");
        Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
        Console.Write("\n   Digite una opcion: ");
    }

    // limitar  entrada de caracteres para que coincida con la BD
    public void ListarRegistros(List<Registro> registros)
    {
        Console.WriteLine("\nREGISTROS DEL DIARIO");
        if (registros.Count() != 0)
        {
            for (int i = 0; i < registros.Count(); i++)
            {
                Console.WriteLine($"[{i}] {registros[i]}");
            }
        }
        else
        {
            Console.WriteLine("No hay registros :(");
        }
    }

    public Registro AgregarRegistro()
    {
        Console.WriteLine("\nAGREGAR ENTRADA AL DIARIO\n");
        Console.WriteLine(" Ingrese X para salir");
        Validaciones validacion = new Validaciones();
        Registro? registro;
        DateTime fecha = validacion.ValidarFecha();
        if (fecha == DateTime.MinValue){return registro = null;};

        string titulo = validacion.ValidacionTitulo();
        if(titulo == String.Empty) { return registro = null; };

        string contenido = validacion.ValidacionContenido();
        if(contenido == String.Empty) {return registro = null; };


        Console.Write("Categoria: ");
        string categoria = Console.ReadLine()  ??"";

        Console.Write("Estado de animo: ");
        string estado = Console.ReadLine() ??"";

        Console.WriteLine("Registro agregado correctamente");
        Console.ReadKey();

        registro = new Registro(fecha.Date,titulo,contenido,categoria,estado);

        return registro;
    }

// colocar expeciones para cuando se oprimas teclas incorrectas
    public int EliminarRegistro( int cantidadRegistros)
    {
        Console.WriteLine("\nELIMINAR ENTRADA DEL DIARIO\n");
        Console.WriteLine(" Ingrese el indice que desea borrar o X para salir");
        Console.Write("> ");
        bool valido = false;
        int  indice;

        do{
            string? inputIndice = Console.ReadLine();
            if (int.TryParse(inputIndice, out indice))
            {
                if(indice >= 0 && indice <= cantidadRegistros)
                {
                    valido = true;

                }else
                {
                    Console.WriteLine("Indice Invalido");
                }
            }else if(inputIndice.ToLower() == "x"){
                indice = -2;
                break;
            }
            else
            {
                Console.WriteLine("Indice  incorrecto");
                Console.ReadKey();
                Console.Write(" Ingrese el indice []: ");
            }
        } while(!valido);
        
        return indice;
    }

    public DateTime ModificarRegistro()
    {
        int cont = 0;
        Console.WriteLine("\n Ingrese la fecha del dato que desea eliminar");
        bool fechaValida = false;
        DateTime fecha;
        do{
            Console.Write("Fecha Formato [dd/MM/yyyy]: ");
            string? imputfecha = Console.ReadLine();
            cont ++;
            if(DateTime.TryParse(imputfecha, out fecha))
            {
                fechaValida = true;

            }else
            {
                Console.WriteLine("formato de fecha incorrecto");
            }
            if(cont == 3)
            {
                Console.WriteLine("Alcanzo el limite de intentos");
            }
        }while(!fechaValida && cont != 3);
        
        return fecha;
    }
}