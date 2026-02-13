using System;

namespace PatronesDeDiseno.Builder
{
    // BUILDER - Construir objetos complejos paso a paso

    // 
    
    public class Pizza // Producto complejo que queremos construir
    {
        // Getters y setters para las partes de la pizza
        public string Masa { get; set; } 
        public string Salsa { get; set; }
        public string Ingredientes { get; set; }

        public void Mostrar() => 
            Console.WriteLine($"Pizza: {Masa}, {Salsa}, {Ingredientes}");
    }

    public class PizzaBuilder // Clase Builder que construye la pizza paso a paso
    {
        private Pizza _pizza = new Pizza(); // Producto complejo que estamos construyendo
         
        public PizzaBuilder ConMasa(string masa) // Metodo para elegir la masa de la pizza
        {
            _pizza.Masa = masa; //  Se asigna la masa a la pizza
            return this;
        }

        public PizzaBuilder ConSalsa(string salsa) // Metodo para elegir la salsa de la pizza
        { 
            _pizza.Salsa = salsa;  // Se asigna la salsa a la pizza
            return this;
        }

        public PizzaBuilder ConIngredientes(string ingredientes) // Metodo para elegir los ingredientes de la pizza
        {
            _pizza.Ingredientes = ingredientes; // Se asignan los ingredientes a la pizza
            return this;
        }

        public Pizza Construir() => _pizza; // Metodo para obtener la pizza construida 
    }

    public class BuilderDemo // Clase de demostración que muestra cómo usar el Builder para construir una pizza
    {
        public static void Ejecutar()
        {
            Console.WriteLine("========== BUILDER ==========\n");

            var pizza = new PizzaBuilder() // Se crea una nueva instancia del Builder
                .ConMasa("Delgada")
                .ConSalsa("Tomate") 
                .ConIngredientes("Pepperoni, Queso")
                .Construir(); // Se construye la pizza con los métodos encadenados

            pizza.Mostrar();
            
        }
    }
}
