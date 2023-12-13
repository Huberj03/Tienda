using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    public class Frutas : Almacen
    {
        private List<Producto> _Frutas;

        public Frutas()
        {
            _Frutas = new List<Producto>();

        }
        public override void addProducto(Producto producto)
        {
            _Frutas.Add(producto);
        }

        public override List<Producto> getProducto(string producto)
        {
            return _Frutas;
        }
    }
}
