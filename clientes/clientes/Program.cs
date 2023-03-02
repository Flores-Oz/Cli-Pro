using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientes
{
    internal class Program
    {
        struct Cliente
        {
            public String nit, nombre, apellido,telefono;
            public DateTime fechaNacimiento;
            public int edad;
        }

        public static void IngresarClientes()
        {
            Console.Clear();
            char salida = 's';
            while (salida == 's')
            {
                Console.Write("Nit: ");
                clientes[pose].nit = Console.ReadLine();
                Console.Write("Nombre Cliente: ");
                clientes[pose].nombre = Console.ReadLine();
                Console.Write("Apellido Cliente: ");
                clientes[pose].apellido = Console.ReadLine();
                Console.Write("Telefono: ");
                clientes[pose].telefono = Console.ReadLine();
                Console.Write("Fecha de Nacimiento: ");
                clientes[pose].fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
                clientes[pose].edad = (2023 - clientes[pose].fechaNacimiento.Year);
                pose++;
                Console.WriteLine("Desea Ingresar otro Cliente S/N ");
                salida = Convert.ToChar(Console.ReadLine());
            }
        }

        public static void MostrarClientes()
        {
            Console.Clear();
            Console.SetCursorPosition(5, 5);
            Console.Write("Nit");
            Console.SetCursorPosition(15, 5);
            Console.Write("Nombre");
            Console.SetCursorPosition(25, 5);
            Console.Write("Apellido");
            Console.SetCursorPosition(35, 5);
            Console.Write("Telefono");
            Console.SetCursorPosition(45, 5);
            Console.Write("Fecha de Nacimiento");
            Console.SetCursorPosition(65, 5);
            Console.Write("Edad");

            for (int i = 0; i < pose; i++)
            {
                Console.SetCursorPosition(5, (6+i));
                Console.WriteLine(clientes[i].nit);
                Console.SetCursorPosition(15, (6+i));
                Console.WriteLine(clientes[i].nombre);
                Console.SetCursorPosition(25, (6+i));
                Console.WriteLine(clientes[i].apellido);
                Console.SetCursorPosition(35, (6+i));
                Console.WriteLine(clientes[i].telefono);
                Console.SetCursorPosition(45, (6+i));
                Console.WriteLine(clientes[i].fechaNacimiento.ToShortDateString());
                Console.SetCursorPosition(65, (6+i));
                Console.WriteLine(clientes[i].edad);
            }
            Console.ReadLine();
        }

        public static void BuscarporNit(String nit)
        {
            Console.Clear();
            int pos = -1;
            for(int i = 0; i< pose; i++)
            {
                if (clientes[i].nit == nit)
                {
                    pos = i;
                }
            }
            if(pos != -1)
            {
                Console.WriteLine("Nombre Cliente: " + clientes[pos].nombre);
                Console.WriteLine("Apellido Cliente " + clientes[pos].apellido);
                Console.WriteLine("Telefono " + clientes[pos].telefono);
                Console.WriteLine("Fecha de Nacimiento " + clientes[pos].fechaNacimiento.ToShortDateString());
                Console.WriteLine("Edad " + clientes[pos].edad);
            }
            else
            {
                Console.WriteLine("El Cliente con este Nit no Existe");
            }
            Console.ReadLine();
        }

        public static void ModificarporNit(String nit)
        {
            Console.Clear();
            int pos = -1;
            for (int i = 0; i < pose; i++)
            {
                if (clientes[i].nit == nit)
                {
                    pos = i;
                }
                if(pos != -1)
                {
                    Console.Write("Nuevo Nombre Cliente: ");
                    clientes[i].nombre = Console.ReadLine();
                    Console.Write("Nuevo Apellido Cliente: ");
                    clientes[i].apellido = Console.ReadLine();
                    Console.Write("Nuevo Telefono: ");
                    clientes[i].telefono = Console.ReadLine();
                    Console.Write("Nueva Fecha de Nacimiento: ");
                    clientes[i].fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
                    clientes[i].edad = (2023 - clientes[i].fechaNacimiento.Year);
                    Console.WriteLine("Cliente Modificado con Exito");
                }
                else
                {
                    Console.WriteLine("Este Cliente no existe");
                }
               
            }
            Console.ReadLine();
        }

        public static void EliminarporNit(String nit)
        {
            Console.Clear();
            Console.Write("Nit a Buscar: ");
            string nitbuscar = Console.ReadLine();
            int pos = -1;
            for (int i = 0; i < pose; i++)
            {
                if (clientes[i].nit == nitbuscar)
                {
                    pos = i;
                }
            }
            if (pos != -1)
            {
                char siono = 's';
                Console.Write("¿Esta seguro de eliminar este cliente? S/N: ");
                siono = Convert.ToChar(Console.ReadLine());
                if (siono == 's' || siono == 'S')
                {
                    for (int x = pos; x < pose; x++)
                    {
                        clientes[x] = clientes[x + 1];
                    }
                    pose--;
                    Console.WriteLine("Cliente Eliminado con exito");
                }
            }
            else
                Console.WriteLine("Este cliente no existe");
        }

       static Cliente[] clientes = new Cliente[10];
       static int pose = 0;

        public static void Menu()
        {
            bool salir = false;
            String net = "";
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("1. Ingresar Empleado");
                Console.WriteLine("2. Mostrar Empleado");
                Console.WriteLine("3. Buscar Empleado por Nit");
                Console.WriteLine("4. Modificar Empleado");
                Console.WriteLine("5. Eliminar Empleado");
                Console.WriteLine("6. Salir");
                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        IngresarClientes();
                        break;
                    case 2:
                        MostrarClientes();
                        break;
                    case 3:
                        Console.WriteLine("Ingrese el Nit del Cliente que desea buscar");
                        net = Console.ReadLine();
                        BuscarporNit(net);
                        break;
                    case 4:
                        Console.WriteLine("Ingrese el Nit del Cliente que desea modificar");
                        net = Console.ReadLine();
                        ModificarporNit(net);
                        break;
                    case 5:
                        Console.WriteLine("Ingrese el Nit del Cliente que desea Eliminar");
                        net = Console.ReadLine();
                        EliminarporNit(net);
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
