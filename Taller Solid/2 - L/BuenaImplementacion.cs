// Buena implementación del Principio de Sustitución de Liskov (Liskov Substitution Principle)
// Las clases derivadas pueden sustituir a sus clases base correctamente

namespace TallerSolid.L.Good
{
    // Abstracción común
    public abstract class Forma
    {
        public abstract int CalcularArea();
    }

    public class Rectangulo : Forma
    {
        public int Ancho { get; set; }
        public int Alto { get; set; }

        public override int CalcularArea()
        {
            return Ancho * Alto;
        }
    }

    public class Cuadrado : Forma
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
            Forma rectangulo = new Rectangulo { Ancho = 5, Alto = 10 };
            Forma cuadrado = new Cuadrado { Lado = 5 };

            Console.WriteLine($"Área rectángulo: {rectangulo.CalcularArea()}"); // 50
            Console.WriteLine($"Área cuadrado: {cuadrado.CalcularArea()}");     // 25
        }
    }
}
