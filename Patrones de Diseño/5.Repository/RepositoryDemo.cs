using System;
using System.Collections.Generic;
using System.Linq;

namespace PatronesDeDiseno.Repository
{
    // REPOSITORY - Abstrae el acceso a datos de la lógica de negocio 
    // Oculta el contenido de la fuente de datos (base de datos, API, etc) y proporciona una interfaz común para interactuar con los datos
    // Definicion logica de negocio: son las reglas, calculos y proccesos que definen como funciona una aplicacion

    public class Producto // Clase producto que representa un producto en el sistema
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }

    public interface IProductoRepository // Interfaz que define las operaciones para manejar productos, como agregar, obtener por ID y obtener todos los productos
    {
        void Agregar(Producto producto); // Metodo para agregar un nuevo producto al repositorio
        Producto ObtenerPorId(int id); // Metodo para obtener un producto por su ID
        IEnumerable<Producto> ObtenerTodos(); // Metodo para obtener todos los productos del repositorio
    }

    public class ProductoRepository : IProductoRepository // Implementacion concreta del repositorio de productos
                                                          // utiliza una lista en memoria para almacenar los productos
    {
        private List<Producto> _productos = new List<Producto>(); // Lista en memoria para almacenar los productos 
        private int _id = 1;

        public void Agregar(Producto producto) // Metodo para agregar un nuevo producto al repositorio, asigna un ID unico y lo agrega a la lista
        {
            producto.Id = _id++;
            _productos.Add(producto); // Agrega el producto a la lista en memoria
            Console.WriteLine($"Agregado: {producto.Nombre}");
        }

        public Producto ObtenerPorId(int id) => _productos.FirstOrDefault(p => p.Id == id); // Metodo para obtener un producto por su ID,
                                                                                            // busca en la lista el producto con el ID especificado y lo devuelve 

        public IEnumerable<Producto> ObtenerTodos() => _productos; // Metodo para obtener todos los productos del repositorio,
                                                                   // devuelve la lista completa de productos almacenados en memoria
    }

    public class RepositoryDemo
    {
        public static void Ejecutar()
        {
            Console.WriteLine("========== REPOSITORY ==========\n");

            IProductoRepository repo = new ProductoRepository(); // Crea una instancia del repositorio de productos

            repo.Agregar(new Producto { Nombre = "Laptop", Precio = 999m }); // Agrega un nuevo producto al repositorio, "Laptop" y un precio de 999
            repo.Agregar(new Producto { Nombre = "Mouse", Precio = 25m }); // Agrega otro producto al repositorio, "Mouse" y un precio de 25

            Console.WriteLine("\nProductos:");
            foreach (var p in repo.ObtenerTodos()) // Itera sobre todos los productos obtenidos del repositorio y los muestra en la consola
                Console.WriteLine($"   [{p.Id}] {p.Nombre} - ${p.Precio}");

        }
    }
}
