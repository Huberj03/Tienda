using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    public class Menu : IMenu
    {
        Almacen g = new Golosinas();
        public void golosinas()
        {
            var des = "";
            var valor = false;

            do
            {
                Console.Clear();
                Console.WriteLine("VENTA DE GOLOSINAS");
                if (g.getProducto("").Count.Equals(0))
                {
                    Console.WriteLine("No hay golosinas");
                    Console.WriteLine("Desea agregar golosinas? Presione la tecla s/n");
                    des = Console.ReadLine();
                    if (des.Equals("s"))
                    {
                        Console.WriteLine("Cuantas golosinas quieres?");
                        int cant = Convert.ToInt16( Console.ReadLine());
                        for (int i = 0; i < cant; i++)
                        {
                            Console.WriteLine("Nueva golosina");
                            Console.WriteLine("Ingrese el ID de la golosina");
                            var id = Console.ReadLine();
                            Console.WriteLine("Ingrese el Nombre de la golosina");
                            var nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese el Precio de la golosina");
                            var precio = Convert.ToDouble(Console.ReadLine());
                            g.addProducto(new Producto{

                                Id = id,
                                Nombre = nombre,
                                Precio = precio
                            });
                        }
                        Console.WriteLine("Desea ir al inicio s/n?");
                        des = Console.ReadLine();

                        if (des.Equals("s"))
                        {
                            valor = true;
                        }
                        else
                        {
                            valor = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Desea ir al inicio s/n?");
                        des = Console.ReadLine();
                        if (des.Equals("s"))
                        {
                            Console.Clear();
                            Console.WriteLine("VENTA DE GOLOSINAS Y FRUTAS");
                        }
                        else
                        {
                            valor = false;
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Lista de Golosinas");
                    foreach (var item in g.getProducto(""))
                    {
                        Console.WriteLine($"Codigo del producto: {item.Id} Nombre del producto: {item.Nombre} Precio del producto: {item.Precio}");
                    }
                    Console.WriteLine("Desea realizar venta de golosinas s/n?");
                    des = Console.ReadLine();

                    if (des.Equals("s"))
                    {
                        ventas();
                    }
                    else
                    {
                        valor = false;
                    }
                }

            } while (valor);
        }

        public double solicitarPago()
        {
            bool pagoCorrecto = false;
            double res = 0;
            while (!pagoCorrecto)
            {
                Console.WriteLine("Como desea realizar el pago con: 10, 5");
                res = double.Parse(Console.ReadLine());
                if (res !=5 && res !=10)
                {
                    Console.WriteLine("Pago invalido");
                }
                else
                {
                    pagoCorrecto = true;
                }
            }
            return res;
        }

        public void ventas()
        {
            double total = 0;
            string des = "";

            do
            {
                Console.WriteLine("Ingrese el producto");
                string producto = Console.ReadLine();
                var productos = g.getProducto(producto);
                while (productos.Count.Equals(0))
                {
                    Console.WriteLine("Golosina no disponible, por favor seleccione  otra");
                    producto = Console.ReadLine();
                    productos = g.getProducto(producto);
                }
                Console.WriteLine($"Su monto a pagar es: {productos[0].Precio} $Dolar");
                double pago = solicitarPago();
                while (pago < productos[0].Precio)
                {
                    Console.WriteLine("Faltan " + (productos[0].Precio - pago).ToString() + " $Dolares");
                    pago += solicitarPago(); 
                }
                Console.WriteLine("Su cambio es de " + (pago - productos[0].Precio).ToString() + " $Dolares");
                total = productos[0].Precio;
                Console.WriteLine("Su pago fue de: " + total.ToString() + " $Dolares");
                Console.WriteLine("¿Desea realizar otra compra? s/n");
                des = Console.ReadLine();

            } while (des.Equals("s"));
        }
    }
}
