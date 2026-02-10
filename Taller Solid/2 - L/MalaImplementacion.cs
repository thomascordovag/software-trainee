// Mala implementación del Principio de Sustitución de Liskov (Liskov Substitution Principle)
// Las subclases no pueden sustituir a la clase base sin problemas

namespace TallerSolid.L.Bad
{
    public class Rectangulo
    {
        public virtual int Ancho { get; set; }
        public virtual int Alto { get; set; }

        public int CalcularArea()
        {
            return Ancho * Alto;
        }
    }

    // Problema: Un cuadrado no puede comportarse como un rectángulo
    public class Cuadrado : Rectangulo
    {
        private int _lado;

        public override int Ancho
        {
            get => _lado;
            set
            {
                _lado = value;
                // Viola LSP: cambiar ancho también cambia alto
            }
        }

        public override int Alto
        {
            get => _lado;
            set
            {
                _lado = value;
                // Viola LSP: cambiar alto también cambia ancho
            }
        }
    }

    // Este código falla
    public class EjemploUso
    {
        public void ProbarArea()
        {
            Rectangulo rect = new Cuadrado();
            rect.Ancho = 5;
            rect.Alto = 10;
            // Esperamos área = 50, pero obtendremos 100
            Console.WriteLine($"Área: {rect.CalcularArea()}");
        }
    }
}
