using Microsoft.Data.SqlClient;


namespace DiarioPersonal.AccesoDatos
{
    //Clase encargada de la conexion a la base de datos
    public class ConexionBD
    {
        private readonly string cadenaConexion = $"Data Source=DESKTOP-TP6BS0E\\SQLEXPRESS; Initial Catalog=DiarioPersonal; User=sa;Password=123;Encrypt=False;";

        public SqlConnection CrearConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
