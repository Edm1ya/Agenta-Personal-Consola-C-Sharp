using DiarioPersonal.AccesoDatos;
using Microsoft.Data.SqlClient;
using DiarioPersonal.Modelos;
using Microsoft.Win32;

//Clase encargada de los metodos para Listas, Crear, Eliminar y Modificar registros de la base de datos
public class DiarioRepositorio{

    public ConexionBD conexion;

    public DiarioRepositorio()
    {
        conexion = new ConexionBD();
    }

    public void CrearBD()
    {

        using (var connection = conexion.CrearConexion())
        {
            connection.Open();

            // Nombre de la tabla que deseas crear
            string tableName = "registros";

            // Sentencia SQL para crear la tabla si no existe
            string createTableQuery = $"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}') " +
                                      $"CREATE TABLE {tableName} ( " +
                                      $"Id INT PRIMARY KEY IDENTITY, " +
                                      $"Fecha DATE NOT NULL, " +
                                      $"Titulo NVARCHAR(100) NOT NULL, " +
                                      $"Contenido NVARCHAR(MAX) NOT NULL, " +
                                      $"Categoria NVARCHAR(50) NOT NULL, " +
                                      $"estado_animo NVARCHAR(50) NOT NULL " +
                                      $");";

            using (SqlCommand command = new SqlCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            Console.WriteLine($"La tabla {tableName} ha sido creada si no existía.");
        }
    }

    public List<Registro> ListarRegistrosBD()
    {
        List<Registro> registros = new List<Registro>();

        string query = "select fecha, titulo, contenido, categoria, estado_animo from registros";

        using (var conex = conexion.CrearConexion())
        {
            SqlCommand command = new SqlCommand(query, conex);

            conex.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DateTime fecha = reader.GetDateTime(0);
                string titulo = reader.GetString(1);
                string contenido = reader.GetString(2);
                string categoria = reader.GetString(3);
                string estadoAnimo = reader.GetString(4);
                Registro registro = new Registro(fecha, titulo, contenido, categoria, estadoAnimo);

                registros.Add(registro);
            }
            reader.Close();
            conex.Close();

        }
        return registros;
    }

    public void Agregar(Registro registro)
    {
        string query = "insert into registros (fecha, titulo, contenido, categoria, estado_animo) values(@fecha, @titulo, @contenido, @categoria, @estado_animo)";

        using (var conex = conexion.CrearConexion())
        {
            var command = new SqlCommand(query, conex);
            command.Parameters.AddWithValue("@fecha",registro.Fecha);
            command.Parameters.AddWithValue("@titulo",registro.Titulo);
            command.Parameters.AddWithValue("@contenido",registro.Contenido);
            command.Parameters.AddWithValue("@categoria",registro.Categoria);
            command.Parameters.AddWithValue("@estado_animo",registro.EstadoDeAnimo);

            conex.Open();
            command.ExecuteNonQuery();
            conex.Close();
        }
    }

    public void Editar(Registro registro, int Id)
    {
        string query = "update registros set fecha=@fecha, titulo=@titulo, contenido=@contenido, categoria=@categoria, estado_animo=@estado_animo where id=@id";

        using (var conex = conexion.CrearConexion())
        {
            var command = new SqlCommand(query, conex);
            command.Parameters.AddWithValue("@fecha",registro.Fecha);
            command.Parameters.AddWithValue("@titulo",registro.Titulo);
            command.Parameters.AddWithValue("@contenido",registro.Contenido);
            command.Parameters.AddWithValue("@categoria",registro.Categoria);
            command.Parameters.AddWithValue("@estado_animo",registro.EstadoDeAnimo);
            command.Parameters.AddWithValue("@id", Id);

            conex.Open();
            command.ExecuteNonQuery();
            conex.Close();
        }
    }
  
    public void Borar(int Id)
    {
        string query = "delete from registros where id=@id";

        using (var conex = conexion.CrearConexion())
        {
            var command = new SqlCommand(query, conex);
            command.Parameters.AddWithValue("@id", Id);

            conex.Open();
            command.ExecuteNonQuery();
            conex.Close();
        }
    }

    public List<Registro> FiltarRegistrosBD(DateTime fechaAFiltrar)
    {
        List<Registro> registros = new List<Registro>();

        string query = "select fecha, titulo, contenido, categoria, estado_animo from registros where fecha=@fecha ";

        using (var conex = conexion.CrearConexion())
        {
            SqlCommand command = new SqlCommand(query, conex);
            command.Parameters.AddWithValue("@fecha", fechaAFiltrar);
            conex.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DateTime fecha = reader.GetDateTime(0);
                string titulo = reader.GetString(1);
                string contenido = reader.GetString(2);
                string categoria = reader.GetString(3);
                string estadoAnimo = reader.GetString(4);
                Registro registroFiltrado = new Registro(fecha, titulo, contenido, categoria, estadoAnimo);

                registros.Add(registroFiltrado);
            }
            reader.Close();
            conex.Close();

        }
        return registros;
    }

    public int ObtenerId(Registro registro)
    {
        int indice = -1;

        string query = "select id from registros where fecha=@fecha and titulo=@titulo and contenido=@contenido and categoria=@categoria and estado_animo=@estado_animo";

        using (var conex = conexion.CrearConexion())
        {
            var command = new SqlCommand(query, conex);
            command.Parameters.AddWithValue("@fecha",registro.Fecha);
            command.Parameters.AddWithValue("@titulo",registro.Titulo);
            command.Parameters.AddWithValue("@contenido",registro.Contenido);
            command.Parameters.AddWithValue("@categoria",registro.Categoria);
            command.Parameters.AddWithValue("@estado_animo",registro.EstadoDeAnimo);

            conex.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                indice = reader.GetInt32(reader.GetOrdinal("id"));
            }
            conex.Close();
        }

        return indice;
    }  
}