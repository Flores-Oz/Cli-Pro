using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    internal class Program
    {
        struct Producto
        {
            public double PrecioCosto, PreciodeVenta, Existencia;
            public String Codigo, Descripcion;
        }

        static Producto[] misProductos = new Producto[10];
        static int contador = 0;

        /* Metodos */
        public static void IngresarProductos() {
            char siono = 's';
            do
            {
                bool bandera = false;
                string auxCod = "";
                do
                {
                    Console.Clear();
                    Console.WriteLine("Ingreso de un Nuevo Producto");
                    Console.Write("Codigo: ");
                    auxCod = Console.ReadLine();
                    bandera = false;
                    for (int i = 0; i < contador; i++)
                    {
                        if (misProductos[i].Codigo == auxCod)
                        {
                            bandera = true;
                        }
                    }
                    if (bandera == true)
                    {
                        Console.WriteLine("Error: Este Codigo ya esta ingresado");
                        Console.ReadKey();
                        Console.Write("¿Desea intentar nuevamente? S/N: ");
                        siono = Convert.ToChar(Console.ReadLine());
                    }
                } while (bandera == true && (siono == 's' || siono == 'S'));
                if (bandera == false)
                {
                    misProductos[contador].Codigo = auxCod;
                    Console.Write("Descripción: ");
                    misProductos[contador].Descripcion = Console.ReadLine();
                    Console.Write("Precio Costo: ");
                    misProductos[contador].PrecioCosto = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Precio Venta: ");
                    misProductos[contador].PreciodeVenta = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Existencia: ");
                    misProductos[contador].Existencia = Convert.ToDouble(Console.ReadLine());
                    contador++;
                    Console.Write("¿Desea ingresar otro Producto? S/N: ");
                    siono = Convert.ToChar(Console.ReadLine());
                }

            } while (siono == 's' || siono == 'S');
        }

        public static void MostrarProductos() 
        {
            Console.Clear();
            Console.SetCursorPosition(5, 5);
            Console.Write("Codigo");
            Console.SetCursorPosition(15, 5);
            Console.Write("Descripción");
            Console.SetCursorPosition(35, 5);
            Console.Write("Precio Costo");
            Console.SetCursorPosition(55, 5);
            Console.Write("Precio Venta");
            Console.SetCursorPosition(75, 5);
            Console.Write("Existencia");

            for (int i = 0; i < contador; i++)
            {
                Console.SetCursorPosition(5, (6 + i));
                Console.WriteLine(misProductos[i].Codigo);
                Console.SetCursorPosition(15, (6 + i));
                Console.WriteLine(misProductos[i].Descripcion);
                Console.SetCursorPosition(35, (6 + i));
                Console.WriteLine(misProductos[i].PrecioCosto);
                Console.SetCursorPosition(55, (6 + i));
                Console.WriteLine(misProductos[i].PreciodeVenta);
                Console.SetCursorPosition(75, (6 + i));
                Console.WriteLine(misProductos[i].Existencia);
            }
            Console.ReadLine();
        }

        public static void BuscarProductos() 
        {
            char siono;
            do
            {
                Console.Clear();
                siono = 'n';
                int pos = -1;
                do
                {
                    Console.Write("Codigo a Buscar: ");
                    string codBuscar = Console.ReadLine();
                    for (int i = 0; i < contador; i++)
                    {
                        if (misProductos[i].Codigo == codBuscar)
                        {
                            pos = i;
                        }
                    }
                    if (pos == -1)
                    {
                        Console.WriteLine("Error: Este Codigo no Existe");
                        Console.ReadKey();
                        Console.Write("¿Desea intentar nuevamente? S/N: ");
                        siono = Convert.ToChar(Console.ReadLine());
                    }
                } while (pos != -1 && (siono == 's' || siono == 'S'));
                if (pos != -1)
                {
                    Console.WriteLine("Codigo: " + misProductos[pos].Codigo);
                    Console.WriteLine("Descripción: "+ misProductos[pos].Descripcion);
                    Console.WriteLine("Precio Costo: "+ misProductos[pos].PrecioCosto);
                    Console.WriteLine("Precio Venta: "+ misProductos[pos].PreciodeVenta);
                    Console.WriteLine("Existencia: "+ misProductos[pos].Existencia);
                    Console.WriteLine("¿Desea Buscar otro Producto? S/N: ");
                    siono = Convert.ToChar(Console.ReadLine());
                }

            } while (siono == 's' || siono == 'S');
        }

        public static void ModificarProductos() 
        {
            char siono;
            do
            {
                Console.Clear();
                siono = 'n';
                int pos = -1;
                do
                {
                    Console.Write("Ingrese el Codigo que Desea Modificar: ");
                    string codBuscar = Console.ReadLine();
                    for (int i = 0; i < contador; i++)
                    {
                        if (misProductos[i].Codigo == codBuscar)
                        {
                            pos = i;
                        }
                    }
                    if (pos == -1)
                    {
                        /*Si no llegara a Encontrar el Producto da "Error"*/
                        Console.WriteLine("Error: Este Codigo no Existe");
                        Console.ReadKey();
                        Console.Write("¿Desea intentar nuevamente? S/N: ");
                        siono = Convert.ToChar(Console.ReadLine());
                    }
                } while (pos != -1 && (siono == 's' || siono == 'S'));
                if (pos != -1)
                {
                    /* Presenta los Datos Actuales del Producto*/
                    Console.SetCursorPosition(50, 3);
                    Console.WriteLine("Datos del Producto Actual");
                    Console.SetCursorPosition(50, 4);
                    Console.WriteLine("Codigo: " + misProductos[pos].Codigo);
                    Console.SetCursorPosition(50, 5);
                    Console.WriteLine("Descripción: " + misProductos[pos].Descripcion);
                    Console.SetCursorPosition(50, 6);
                    Console.WriteLine("Precio Costo: " + misProductos[pos].PrecioCosto);
                    Console.SetCursorPosition(50, 7);
                    Console.WriteLine("Precio Venta: " + misProductos[pos].PreciodeVenta);
                    Console.SetCursorPosition(50, 8);
                    Console.WriteLine("Existencia: " + misProductos[pos].Existencia);

                    /* Modifica los Datos Actuales del Producto*/
                    Console.SetCursorPosition(0, 3);
                    Console.Write("Nueva Descripciòn: ");
                    misProductos[pos].Descripcion = Console.ReadLine();
                    Console.Write("Nuevo Precio Costo: ");
                    misProductos[pos].PrecioCosto = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Nuevo Precio Venta: " );
                    misProductos[pos].PreciodeVenta = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Nueva Existencia: " );
                    misProductos[pos].Existencia = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("¿Desea Modificar otro Producto? S/N: ");
                    siono = Convert.ToChar(Console.ReadLine());
                }

            } while (siono == 's' || siono == 'S');
        }
    

        public static void EliminarProductos() 
        {
            char siono;
            do
            {
                Console.Clear();
                siono = 'n';
                int pos = -1;
                do
                {
                    Console.Write("Ingrese el Codigo que Desea Eliminar: ");
                    string codBuscar = Console.ReadLine();
                    for (int i = 0; i < contador; i++)
                    {
                        if (misProductos[i].Codigo == codBuscar)
                        {
                            pos = i;
                        }
                    }
                    if (pos == -1)
                    {
                        /*Si no llegara a Encontrar el Producto da "Error"*/
                        Console.WriteLine("Error: Este Codigo no Existe");
                        Console.ReadKey();
                        Console.Write("¿Desea intentar nuevamente? S/N: ");
                        siono = Convert.ToChar(Console.ReadLine());
                    }
                } while (pos != -1 && (siono == 's' || siono == 'S'));
                if (pos != -1)
                {
                    char desicion = 's';
                    Console.Write("¿Esta seguro de eliminar este Producto? S/N: ");
                    desicion = Convert.ToChar(Console.ReadLine());
                    if (desicion == 's' || desicion == 'S')
                    {
                        for (int x = pos; x < contador; x++)
                        {
                            misProductos[x] = misProductos[x + 1];
                        }
                        contador--;
                        Console.WriteLine("Producto Eliminado con exito");
                    }
                    else { 
                        Console.WriteLine("Producto no Eliminado");

                    } 
                    Console.WriteLine("¿Desea Eliminar otro Producto? S/N: ");
                    siono = Convert.ToChar(Console.ReadLine());
                }

            } while (siono == 's' || siono == 'S');
        }
    

        /* Menu */
        public static void Menu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("1. Ingresar Producto");
                Console.WriteLine("2. Mostrar Productos");
                Console.WriteLine("3. Buscar Producto por Codigo");
                Console.WriteLine("4. Modificar Producto");
                Console.WriteLine("5. Eliminar Producto");
                Console.WriteLine("6. Salir");
                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        IngresarProductos();
                        break;
                    case 2:
                        MostrarProductos();
                        break;
                    case 3:
                        BuscarProductos();
                        break;
                    case 4:
                        ModificarProductos();
                        break;
                    case 5:
                        EliminarProductos();
                        break;
                    case 6:
                        Console.WriteLine("Has elegido salir de la aplicación");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Elige una opcion entre 1 y 5");
                        break;
                }

            }
        }
    

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
