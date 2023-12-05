using Microsoft.Data.SqlClient;


namespace DiarioPersonal.AccesoDatos
{
    //Clase encargada de la conexion a la base de datos
    public class ConexionBD
    {
        private string servidor = "DESKTOP-TP6BS0E\\SQLEXPRESS";
        private string basedatos = "DiarioPersonal";
        private string usuario = "sa";
        private string password =  "123";

        private string cadenaConexion;
        public SqlConnection CrearConexion()
        {
            cadenaConexion = $"Data Source={servidor}; Initial Catalog={basedatos}; User={usuario};Password={password};Encrypt=False;";

            return new SqlConnection(cadenaConexion);
        }
    }
}
