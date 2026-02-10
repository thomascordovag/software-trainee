// Buena implementación del Principio de Sustitución de Liskov (Liskov Substitution Principle)
// Las clases derivadas pueden sustituir a sus clases base correctamente
// La idea de este principio es crear una clase que sea mas generica y que las clases especificas hereden de ella.

using System;

namespace TallerSolid.L.BI
{
    // Abstracción común
    public abstract class Forma // Clase base generica para formas geométricas
    {
        public abstract int CalcularArea();
    }

    public class Rectangulo : Forma // Clase específica que hereda de Forma 
    {
        public int Ancho { get; set; }
        public int Alto { get; set; }

        public override int CalcularArea()
        {
            return Ancho * Alto;
        }
    }

    public class Cuadrado : Forma // Clase específica que hereda de Forma
    {
        public int Lado { get; set; }

        public override int CalcularArea()
        {
            return Lado * Lado;
        }
    }

    // Ahora el código funciona correctamente
    public class EjemploUso
    {
        public void ProbarAreas()
        {
            Forma rectangulo = new Rectangulo { Ancho = 5, Alto = 10 }; // Se puede usar la clase base para crear un rectángulo
            Forma cuadrado = new Cuadrado { Lado = 5 }; // Se puede usar la clase base para crear un cuadrado

            Console.WriteLine($"Área rectángulo: {rectangulo.CalcularArea()}"); // 50
            Console.WriteLine($"Área cuadrado: {cuadrado.CalcularArea()}");     // 25
        }
    }
}
