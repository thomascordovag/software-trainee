using System;

namespace PatronesDeDiseno.Strategy
{
    // STRATEGY - Reemplaza switch/if-else con polimorfismo
    // Definicion polimorfismo: es la capacidad de un objeto de tomar muchas formas,
    // una clase base puede tener varias clases derivadas que implementan su comportamiento de diferentes maneras

    // Ejemplo de como seria si no se ocupara el patron Strategy (con switch)
    public class CalculadoraSinPatron
    {
        public decimal Calcular(decimal precio, string tipo) // Metodo que calcula el descuento basado en el tipo,
                                                             // utilizando un switch para determinar la logica de descuento
        {
            return tipo switch
            {
                "regular" => precio * 0.05m,
                "premium" => precio * 0.15m,
                _ => 0
            };
        }
    }
 
    // Ejemplo con Strategy, cada tipo de descuento es una clase que implementa la interfaz IDescuento
    public interface IDescuento // Interfaz que define el contrato para calcular el descuento,
                                // cada clase que implemente esta interfaz debe proporcionar su propia implementacion del metodo Calcular
    {
        decimal Calcular(decimal precio);
    }

    public class DescuentoRegular : IDescuento // Clase que implementa el descuento regular, que hereda de la interfaz IDescuento
    {
        public decimal Calcular(decimal precio) => precio * 0.05m;
    }

    public class DescuentoPremium : IDescuento // Clase que implementa el descuento premium, que hereda de la interfaz IDescuento
    {
        public decimal Calcular(decimal precio) => precio * 0.15m;
    }

    public class Carrito // Clase que representa un carrito de compras, que utiliza una estrategia de descuento para calcular el total final
    {
        private IDescuento _descuento; 

        public void SetDescuento(IDescuento descuento) => _descuento = descuento; 

        public void Procesar(decimal total) 
        {
            var descuento = _descuento.Calcular(total); // Calcula el descuento utilizando la estrategia actual, llamando al metodo Calcular de la instancia de IDescuento
            Console.WriteLine($"Total: ${total} | Descuento: ${descuento} | Final: ${total - descuento}");
        }
    }

    public class StrategyDemo
    {
        public static void Ejecutar()
        {
            Console.WriteLine("========== STRATEGY ==========\n");

            var carrito = new Carrito(); // Crea una instancia de Carrito, que es la clase que utilizara las estrategias de descuento

            carrito.SetDescuento(new DescuentoRegular()); // Se ocupa descuento regular, se crea una instancia de DescuentoRegular y
                                                          // se asigna al carrito utilizando el metodo SetDescuento
            carrito.Procesar(100m);

            carrito.SetDescuento(new DescuentoPremium()); // Se cambia a descuento premium, se crea una instancia de DescuentoPremium y
                                                          // se asigna al carrito utilizando el metodo SetDescuento
            carrito.Procesar(100m);

        }
    }
}
