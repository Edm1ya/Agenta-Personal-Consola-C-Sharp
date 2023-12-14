using DiarioPersonal.Modelos;

public class Intefaz
{
    public void Titulo() // Intefaz de titulo
    {
        Console.Clear();
        Console.WriteLine(
        "╔═════════════════════════════════════════════════╗" +
        "\r\n                 DIARIO PERSONAL                  \r\n"+
        "╚═════════════════════════════════════════════════╝"
        );
    }

    public void MenuAcercaDe() // Intefaz de Menu Acerca De
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
    }

    public void MenuPrincipal() // Intefaz de Menu Principal
    {
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

    public void MenuDiario() // Intefaz de Menu Diario
    {
        Console.WriteLine("\n\n▼▼|| MENU DE OPCIONES  ||▼▼");
        Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
        Console.WriteLine("" +
            "\n ► 1. - Listar Registros" +                   
            "\n ► 2. - Agregar Registros" +
            "\n ► 3. - Eliminar Registros" +
            "\n ► 4. - Modificar Registros" +
            "\n ► 5. - Filtrar Registros" +
            "\n___________________________________________________" +
            "\n___________________________________________________" +
            "\n\n ► 6. - Volver Atras" +
            "\n ► 7. - Salir\n");
        Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
        Console.Write("\n   Digite una opcion: ");
    }

}