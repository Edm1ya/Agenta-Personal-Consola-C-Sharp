using DiarioPersonal.AccesoDatos;
using DiarioPersonal.Modelos;

namespace DiarioPersonal.Servicios
{
    public class DiarioServicio
    {
        public Diario diario;
        private readonly DiarioRepositorio diarioRepositorio;
        public List<Registro> registros;

        public DiarioServicio()
        {
            diarioRepositorio = new DiarioRepositorio();
            registros = new List<Registro>();
            diario = new Diario();
        }

        public void ActualizarRegistros()
        {
            foreach (var registro in diarioRepositorio.ListarRegistrosBD())
            {
                diario.AgregarRegistro(registro);
            }
        }

        public void AgregarRegistro(Registro registro)
        {
            diarioRepositorio.Agregar(registro);

            diario.AgregarRegistro(registro);
        }

        public void BorrarRegistro(int indice)
        {
            registros = diario.ListarRegistros();
            int indiceBD = diarioRepositorio.ObtenerId(registros[indice]);
            diarioRepositorio.Borar(indiceBD);

            diario.BorrarRegistro(indice);
        }

        public void ModificarRegistro(Registro registro, int indice)
        {

            registros = diario.ListarRegistros();
            int indiceBD = diarioRepositorio.ObtenerId(registros[indice]);
            diarioRepositorio.Editar(registro, indiceBD);

            diario.ModificarRegistro(registro, indice);
        }

        public List<Registro> ListarRegistros()
        {
            List<Registro> registrosPorListar = new List<Registro>();
            if (diario.ListarRegistros().Count == diarioRepositorio.ListarRegistrosBD().Count)
            {
                registrosPorListar = diario.ListarRegistros();
            }

           return  registrosPorListar;
        }

        public List<Registro> FiltarRegistros(DateTime fechaAFiltrar)
        {
            return diarioRepositorio.FiltarRegistrosBD(fechaAFiltrar);
        }
    }
}
