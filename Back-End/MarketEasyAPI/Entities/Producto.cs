using System;
namespace MarketEasyAPI.Entities
{
    public class Producto
    {
        public Producto()
        {
            this.ProductoId = Guid.NewGuid();
        }

        public Guid ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public Int32 Cantidad { get; set; }
        public Int32 Precio { get; set; }
        public string Descripcion { get; set; }
    }
}
