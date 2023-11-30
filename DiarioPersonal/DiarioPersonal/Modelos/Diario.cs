using DiarioPersonal.Interfaces;
namespace DiarioPersonal.Modelos
{
    public class Diario : IDiario
    {
        public List<Registro> registros;

        public Diario()
        {
            registros = new List<Registro>();
        }

        public void AgregarRegistro(Registro registro)
        {
            registros.Add(registro);
        }

        public void BorrarRegistro(int indice)
        {
            Registro registro = registros[indice];
            registros.Remove(registro);
        }

        public void ModificarRegistro(Registro registro, int indice)
        {
            for (int i = 0; i < registros.Count; i++)
            {
                if (i == indice)
                {
                    registros[i].Fecha = registro.Fecha;
                    registros[i].Titulo = registro.Titulo;
                    registros[i].Contenido = registro.Contenido;
                    registros[i].Categoria = registro.Categoria;
                    registros[i].EstadoDeAnimo = registro.EstadoDeAnimo;
                }
            }
        }
        public List<Registro> ListarRegistros()
        {
            return registros;
        }

    }
}