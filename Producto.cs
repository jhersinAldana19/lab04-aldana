using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04_aldana
{
    class Producto
    {
        // Atributos
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }
        public string CantidadPorUnidad { get; set; }
        public double PrecioUnidad { get; set; }
        public int UnidadesEnExistencia { get; set; }
        public int UnidadesEnPedido { get; set; }
        public int NivelNuevoPedido { get; set; }
        public bool Suspendido { get; set; }
        public string CategoriaProducto { get; set; }
    }
}
