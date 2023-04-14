using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lob_2_poo3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al Supermercado");

            Console.Write("Ingrese su nombre de usuario: ");
            string nombreUsuario = Console.ReadLine();

            Console.Write("¿Es usted un vendedor o un administrador? (Ingrese 1 para vendedor, 2 para administrador): ");
            int opcionUsuario = int.Parse(Console.ReadLine());

            Usuario usuario;


            if (opcionUsuario == 1)
            {
                usuario = new Vendedor(nombreUsuario);
            }
            else if (opcionUsuario == 2)
            {
                usuario = new Administrador(nombreUsuario);
            }
            else
            {
                Console.WriteLine("Opción no válida");
                return;
            }

            while (true)
            {
                Console.WriteLine($"Bienvenido, {usuario.Nombre}");
                Console.WriteLine("¿Qué desea hacer?");

                if (usuario is Vendedor)
                {
                    Console.WriteLine("1. Vender");
                }

                if (usuario is Administrador)
                {
                    Console.WriteLine("2. Administrar");
                }

                Console.WriteLine("0. Salir");

                int opcionMenu = int.Parse(Console.ReadLine());

                if (opcionMenu == 0)
                {
                    Console.WriteLine("Hasta luego.");
                    break;
                }

                switch (opcionMenu)
                {
                    case 1:
                        if (usuario is Vendedor)
                        {
                            Vendedor vendedor = (Vendedor)usuario;
                            Console.WriteLine("Productos disponibles:");
                            foreach (Producto producto in vendedor.Productos)
                            {
                                Console.WriteLine($"{producto.Nombre} ({producto.Categoria}, {producto.FechaCaducidad}, ${producto.Precio})");
                            }
                            vendedor.Vender();
                        }
                        else
                        {
                            Console.WriteLine("Opción no válida");
                        }
                        break;
                    case 2:
                        if (usuario is Administrador)
                        {

                            Administrador administrador = (Administrador)usuario;
                            Console.WriteLine("¿Qué desea hacer?");
                            Console.WriteLine("1. Agregar producto");
                            Console.WriteLine("2. Agregar área");
                            Console.WriteLine("3. Agregar categoría");

                            int opcionAdministrador = int.Parse(Console.ReadLine());

                            switch (opcionAdministrador)
                            {
                                case 1:
                                    Administrador admin = new Administrador(nombreUsuario);
                                    
                                    admin.AgregarProducto();

                                    break;
                                case 2:
                                    // Lógica para agregar área
                                    Administrador aadmin = new Administrador(nombreUsuario);
                                    aadmin.AgregarArea();
                                    break;
                                case 3:
                                    // Lógica para agregar categoría
                                    Administrador aaadmin = new Administrador(nombreUsuario);
                                    aaadmin.AgregarCategoria();
                                    break;
                                default:
                                    Console.WriteLine("Opción no válida");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Opción no válida");
                        }
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
        }
    }

    public class Producto
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string FechaCaducidad { get; set; }
        public double Precio { get; set; }

        public Producto(string nombre, string categoria, string fechaCaducidad, double precio)
        {
            Nombre = nombre;
            Categoria = categoria;
            FechaCaducidad = fechaCaducidad;
            Precio = precio;
        }
    }

    public class Usuario
    {
        public string Nombre { get; set; }

        public Usuario(string nombre)
        {
            Nombre = nombre;
        }
    }

    public class Administrador : Usuario
    {
        public List<Producto> Productos { get; set; }
        public List<string> Categorias { get; set; }
        public List<string> Areas { get; set; }

        public Administrador(string nombre) : base(nombre)
        {
            Productos = new List<Producto>();
            Categorias = new List<string>() { "Lácteos", "Panadería", "Huevos y lácteos" };
            Areas = new List<string>() { "Área 1", "Área 2", "Área 3" };
        }

        public void AgregarProducto()
        {
            Console.Write("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la categoría del producto: ");
            string categoria = Console.ReadLine();

            Console.Write("Ingrese la fecha de caducidad del producto: ");
            string fechaCaducidad = Console.ReadLine();

            Console.Write("Ingrese el precio del producto: ");
            double precio = Convert.ToDouble(Console.ReadLine());

            Producto nuevoProducto = new Producto(nombre, categoria, fechaCaducidad, precio);

            Productos.Add(nuevoProducto);

            Console.WriteLine($"El producto {nuevoProducto.Nombre} ha sido agregado correctamente");
        }


        public void AgregarCategoria()
        {
            Console.Write("Ingrese el nombre de la nueva categoría: ");
            string nuevaCategoria = Console.ReadLine();

            Categorias.Add(nuevaCategoria);

            Console.WriteLine($"La categoría {nuevaCategoria} ha sido agregada correctamente");
        }

        public void AgregarArea()
        {
            Console.Write("Ingrese el nombre de la nueva área: ");
            string nuevaArea = Console.ReadLine();

            Areas.Add(nuevaArea);

            Console.WriteLine($"El área {nuevaArea} ha sido agregada correctamente");
        }
    }




    public class Vendedor : Usuario
    {
        public List<Producto> Productos { get; set; }

        public Vendedor(string nombre) : base(nombre)
        {
            Productos = new List<Producto>()
            {

            new Producto("leche", "Lácteos", "15/05/2023", 20.0),
            new Producto("pan", "Panadería", "17/04/2023", 10.0),
            new Producto("huevos", "Huevos y lácteos", "20/04/2023", 25.0)
        
            };
        
        }

        public void Vender()
        {
            Console.Write("Ingrese el nombre del producto que desea comprar: ");
            string nombreProducto = Console.ReadLine();

            Producto productoEncontrado = Productos.Find(p => p.Nombre == nombreProducto);

            if (productoEncontrado != null)
            {
                Console.WriteLine($"El precio de {productoEncontrado.Nombre} es de ${productoEncontrado.Precio}");
                Console.WriteLine("Muchas Gracias por su Compra");
            }
            else
            {
                Console.WriteLine("Producto no encontrado");
            }
        }
    }
}
