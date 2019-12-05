using System;
namespace MarketEasyAPI.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            this.UsuarioId = Guid.NewGuid();
        }

        public Guid UsuarioId { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public bool IsAdmin { get; set; }
    }
}
