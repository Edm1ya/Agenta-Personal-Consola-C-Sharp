using DiarioPersonal.Modelos;

namespace DiarioPersonal.Interfaces
{
    public interface IDiario
    {
        public void Agregar(Registro registro);
        public void Borrar(int id);
        public void Editar(Registro registro, int indice);
        public List<Registro> ListarRegistros();
    }
}
