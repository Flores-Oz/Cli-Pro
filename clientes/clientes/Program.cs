using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
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
        static Cliente[] clientes = new Cliente[10];
        static int pose = 0;
        static String ubicacion = "C:/Ficheros/clientes.txt";

        /* Carga de Datos */
        public static void CargarClientes()
        {
            StreamReader leer = new StreamReader(ubicacion);
            while(!leer.EndOfStream)
            {
                string linea = leer.ReadLine();
                string[] aux = linea.Split(',');
                clientes[pose].nit = aux[0];
                clientes[pose].nombre = aux[1];
                clientes[pose].apellido = aux[2];
                clientes[pose].telefono = aux[3];
                clientes[pose].fechaNacimiento = Convert.ToDateTime(aux[4]);
                clientes[pose].edad = Convert.ToInt32(aux[5]);
                pose++;
            }
            leer.Close();
        }

        /* Metodos */
        public static void IngresarClientes()
        {
            char siono = 's';
            do
            {
                bool bandera = false;
                string auxNit = "";
                do
                {
                    Console.Clear();
                    Console.WriteLine("Ingreso de Nuevo Cliente");
                    Console.Write("Nit: ");
                    auxNit = Console.ReadLine();
                    bandera = false;
                    for (int i = 0; i < pose; i++)
                    {
                        if (clientes[i].nit == auxNit)
                        {
                            bandera = true;
                        }
                    }
                    if (bandera)
                    {
                        Console.WriteLine("Error: Este Nit ya esta registrado en el Sistema");
                        Console.ReadKey();
                        Console.Write("Desea Intentar Nuevamente S/N: ");
                        siono = Convert.ToChar(Console.ReadLine());
                    }
                } while (bandera == true && (siono == 's' || siono == 'S'));
                if (!bandera)
                {
                    clientes[pose].nit = auxNit;
                    Console.Write("Nombre Cliente: ");
                    clientes[pose].nombre = Console.ReadLine();
                    Console.Write("Apellido Cliente: ");
                    clientes[pose].apellido = Console.ReadLine();
                    Console.Write("Telefono: ");
                    clientes[pose].telefono = Console.ReadLine();
                    Console.Write("Fecha de Nacimiento: ");
                    clientes[pose].fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
                    clientes[pose].edad = (2023 - clientes[pose].fechaNacimiento.Year);
                    /*Ingreso de Clientes al Fichero*/
                    String newCliente = clientes[pose].nit + "," + clientes[pose].nombre + "," + clientes[pose].apellido + "," + clientes[pose].telefono + "," +
                        clientes[pose].fechaNacimiento + "," + clientes[pose].edad;
                    StreamWriter escribir = new StreamWriter(ubicacion,true);
                    escribir.WriteLine(newCliente);
                    escribir.Close();
                    pose++;
                    Console.WriteLine("Desea Ingresar otro Cliente S/N ");
                    siono = Convert.ToChar(Console.ReadLine());
                }
            } while (siono == 's' || siono == 'S');
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

        public static void BuscarporNit()
        {
            char siono;
            do
            {
                Console.Clear();
                siono = 'n';
                int pos = -1;
                do
                {
                    Console.Write("Nit a Buscar: ");
                    string nit = Console.ReadLine();
                    for (int i = 0; i < pose; i++)
                    {
                        if (clientes[i].nit == nit)
                        {
                            pos = i;
                        }
                    }
                    if(pos == -1)
                    {
                        Console.WriteLine("Error: Este Nit no Existe");
                        Console.ReadKey();
                        Console.WriteLine("¿Desea Intentar Nuevamente? S/N: ");
                        siono = Convert.ToChar(Console.ReadLine());
                    }
                } while (pos != -1 && (siono == 's' || siono == 'S'));
                if (pos != -1)
                {
                    Console.WriteLine("Nombre Cliente: " + clientes[pos].nombre);
                    Console.WriteLine("Apellido Cliente " + clientes[pos].apellido);
                    Console.WriteLine("Telefono " + clientes[pos].telefono);
                    Console.WriteLine("Fecha de Nacimiento " + clientes[pos].fechaNacimiento.ToShortDateString());
                    Console.WriteLine("Edad " + clientes[pos].edad);
                    Console.WriteLine("¿Desea Buscar otro Nit? S/N: ");
                    siono = Convert.ToChar(Console.ReadLine());
                }
            }while((siono == 's' || siono == 'S'));
        }

        public static void ModificarporNit()
        {
            char siono;
            do
            {
                Console.Clear();
                siono = 'n';
                int pos = -1;
                do
                {
                    Console.Write("Ingrese el Nit que Desea Modificar: ");
                    string nitBuscar = Console.ReadLine();
                    for (int i = 0; i < pose; i++)
                    {
                        if (clientes[i].nit == nitBuscar)
                        {
                            pos = i;
                        }
                    }
                    if (pos == -1)
                    {
                        /*Si no llegara a Encontrar el Producto da "Error"*/
                        Console.WriteLine("Error: Este Nit no Existe");
                        Console.ReadKey();
                        Console.Write("¿Desea intentar nuevamente? S/N: ");
                        siono = Convert.ToChar(Console.ReadLine());
                    }
                } while (pos != -1 && (siono == 's' || siono == 'S'));
                if (pos != -1)
                {
                    /* Presenta los Datos Actuales del Cliente*/
                    Console.SetCursorPosition(50, 3);
                    Console.WriteLine("Datos del Cliente Actual");
                    Console.SetCursorPosition(50, 4);
                    Console.WriteLine("Nombre Cliente: " + clientes[pos].nombre);
                    Console.SetCursorPosition(50, 5);
                    Console.WriteLine("Apellido Cliente " + clientes[pos].apellido);
                    Console.SetCursorPosition(50, 6);
                    Console.WriteLine("Telefono " + clientes[pos].telefono);
                    Console.SetCursorPosition(50, 7);
                    Console.WriteLine("Fecha de Nacimiento " + clientes[pos].fechaNacimiento.ToShortDateString());
                    Console.SetCursorPosition(50, 8);
                    Console.WriteLine("Edad " + clientes[pos].edad);

                    /* Modifica los Datos Actuales del Cliente*/
                    Console.SetCursorPosition(0, 3);
                    Console.Write("Nuevo Nombre Cliente: ");
                    clientes[pos].nombre = Console.ReadLine();
                    Console.Write("Nuevo Apellido Cliente: ");
                    clientes[pos].apellido = Console.ReadLine();
                    Console.Write("Nuevo Telefono: ");
                    clientes[pos].telefono = Console.ReadLine();
                    Console.Write("Nueva Fecha de Nacimiento: ");
                    clientes[pos].fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
                    clientes[pos].edad = (2023 - clientes[pose].fechaNacimiento.Year);
                    /*Actualizacion conjunto elimnacion y creacion del archivo*/
                    StreamWriter escribir = new StreamWriter(ubicacion);
                    for (int i = 0; i < pose; i++)
                    {
                        String newCliente = clientes[i].nit + "," + clientes[i].nombre + "," + clientes[i].apellido + "," + clientes[i].telefono + "," +
                        clientes[i].fechaNacimiento + "," + clientes[i].edad;
                        escribir.WriteLine(newCliente);
                        escribir.WriteLine(newCliente);

                    }
                    escribir.Close();
                    Console.WriteLine("Cliente Modificado con Exito");
                    Console.WriteLine("¿Desea Modificar otro Cliente? S/N: ");
                    siono = Convert.ToChar(Console.ReadLine());
                }
            } while (siono == 's' || siono == 'S');
      
    }

        public static void EliminarporNit()
        {
            char siono;
            do
            {
                Console.Clear();
                siono = 'n';
                int pos = -1;
                do
                {
                    Console.Write("Ingrese el Nit que Desea Eliminar: ");
                    string nitBuscar = Console.ReadLine();
                    for (int i = 0; i < pose; i++)
                    {
                        if (clientes[i].nit == nitBuscar)
                        {
                            pos = i;
                        }
                    }
                    if (pos == -1)
                    {
                        /*Si no llegara a Encontrar el Producto da "Error"*/
                        Console.WriteLine("Error: Este Nit no Existe");
                        Console.ReadKey();
                        Console.Write("¿Desea intentar nuevamente? S/N: ");
                        siono = Convert.ToChar(Console.ReadLine());
                    }
                } while (pos != -1 && (siono == 's' || siono == 'S'));
                if (pos != -1)
                {
                    char desicion = 's';
                    Console.Write("¿Esta seguro de eliminar este Cliente? S/N: ");
                    desicion = Convert.ToChar(Console.ReadLine());
                    if (desicion == 's' || desicion == 'S')
                    {
                        for (int x = pos; x < pose; x++)
                        {
                            clientes[x] = clientes[x + 1];
                        }
                        pose--;
                        /*Actualizacion conjunto elimnacion y creacion del archivo*/
                        StreamWriter escribir = new StreamWriter(ubicacion);
                        for (int i = 0; i < pose; i++)
                        {
                            String newCliente = clientes[pose].nit + "," + clientes[pose].nombre + "," + clientes[pose].apellido + "," + clientes[pose].telefono + "," +
                            clientes[pose].fechaNacimiento + "," + clientes[pose].edad;
                            escribir.WriteLine(newCliente);
                        }
                        escribir.Close();
                        Console.WriteLine("Cliente Eliminado con Exito");
                        Console.WriteLine("¿Desea Eliminar otro Cliente? S/N: ");
                        siono = Convert.ToChar(Console.ReadLine());
                    }
                } 
            } while (siono == 's' || siono == 'S');
        }

        public static void Menu()
        {
            CargarClientes();
            bool salir = false;
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
                        BuscarporNit();
                        break;
                    case 4:
                        ModificarporNit();
                        break;
                    case 5: 
                        EliminarporNit();
                        break;
                    case 6:
                        Console.WriteLine("Has elegido salir de la aplicación");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Elige una opcion entre 1 y 6");
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
