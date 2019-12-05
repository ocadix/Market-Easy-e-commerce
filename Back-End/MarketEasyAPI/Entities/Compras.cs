using System;
namespace MarketEasyAPI.Entities
{
    public class Compras
    {
        public Compras()
        {
            this.ComprasId = Guid.NewGuid();
        }

        public Guid ComprasId { get; set; }
        public DateTime Fecha { get; set; }
        public string UsuarioId { get; set; }  
        public Usuario Usuario { get; set; }
        public string ProductoId { get; set; }
        public Producto Producto { get; set; }
        public Int32 Cantidad { get; set; }
    }
}
