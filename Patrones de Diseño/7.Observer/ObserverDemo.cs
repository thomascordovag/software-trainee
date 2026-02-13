using System;
using System.Collections.Generic;

namespace PatronesDeDiseno.Observer
{
    // OBSERVER - Notifica automáticamente a múltiples objetos
    
    public interface IObserver // Interfaz común para los observadores que actualiza el precio 
    {
        void Actualizar(decimal precio);
    }

    public class Producto // Clase producto que mantiene una lista de observadores y notifica cambios de precio
    {
        private List<IObserver> _observers = new List<IObserver>();
        private decimal _precio;

        public void Suscribir(IObserver observer) => _observers.Add(observer); // Metodo para agregar un observador

        private void Notificar() // Metodo para notificar a todos los observadores sobre el cambio de precio
        {
            foreach (var obs in _observers) // Itera sobre cada observador y llama al metodo Actualizar
                obs.Actualizar(_precio);
        }

        public decimal Precio 
        {
            get => _precio; // Getter del precio 
            set // Setter del precio
            {
                _precio = value; // Asigna el nuevo precio
                Notificar(); // Llamada a Notificar para informar a los observadores
            }
        }
    }

    public class Cliente : IObserver // Clase cliente que hereda de IObserver y recibe actualizaciones de precio
    {
        private string _nombre;
        public Cliente(string nombre) => _nombre = nombre; // Constructor que asigna el nombre del cliente

        public void Actualizar(decimal precio) =>  // Implementación del método Actualizar que muestra el nuevo precio
            Console.WriteLine($" {_nombre}: Precio actualizado a ${precio}");
    }

    public class ObserverDemo
    {
        public static void Ejecutar()
        {
            Console.WriteLine("========== OBSERVER ==========\n");

            var producto = new Producto(); // Instancia de Producto

            producto.Suscribir(new Cliente("Juan")); // Suscripción de clientes observadores
            producto.Suscribir(new Cliente("María")); 

            Console.WriteLine("Cambiando precio:");
            producto.Precio = 100m; // Cambio de precio que notifica a los observadores

            Console.WriteLine("\nCambiando precio nuevamente:");
            producto.Precio = 80m; // Otro cambio de precio que notifica a los observadores

        }
    }
}
