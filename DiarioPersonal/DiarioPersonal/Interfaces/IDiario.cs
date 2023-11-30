using DiarioPersonal.Modelos;

namespace DiarioPersonal.Interfaces
{
    public interface IDiario
    {
        public void AgregarRegistro(Registro registro);
        public void BorrarRegistro(int indice);
        public void ModificarRegistro(Registro registro, int indice);
        public List<Registro> ListarRegistros();
    }
}
