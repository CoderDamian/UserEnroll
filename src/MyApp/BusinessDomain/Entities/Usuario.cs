using BusinessDomain.Seedwork;

namespace BusinessDomain.Entities
{
    public class Usuario : MyEntity
    {
        public string Nombres { get; private set; } = string.Empty;
        public string Apellidos { get; private set; } = string.Empty;
        public string CorreoElectronico { get; private set; } = string.Empty;
        public string Contrasena { get; private set; } = string.Empty;

        public Usuario(string nombres, string apellidos, string correoElectronico, string contrasena)
        {
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.CorreoElectronico = correoElectronico;
            SetContrasena(contrasena);
        }

        public void SetContrasena(string contrasena)
        {
            if (contrasena.Length > 5)
            {
                throw new ArgumentException("La contraena no puede contener mas de 5 caracteres");
            }
            else
            {
                this.Contrasena = contrasena;
            }
        }
    }
}
