// Buena implementación del Principio de Responsabilidad Única (Single Responsibility Principle)
// Cada clase tiene una única responsabilidad

namespace TallerSolid.S.Good
{
    // Responsabilidad única: Representar un empleado
    public class Empleado
    {
        public string Nombre { get; set; }
        public decimal Salario { get; set; }
    }

    // Responsabilidad única: Calcular salarios
    public class CalculadoraSalario
    {
        public decimal CalcularSalarioNeto(Empleado empleado)
        {
            return empleado.Salario * 0.85m;
        }
    }

    // Responsabilidad única: Persistencia
    public class EmpleadoRepository
    {
        public void Guardar(Empleado empleado)
        {
            Console.WriteLine($"Guardando empleado {empleado.Nombre} en la base de datos");
        }
    }

    // Responsabilidad única: Generación de reportes
    public class ReporteEmpleado
    {
        private readonly CalculadoraSalario _calculadora;

        public ReporteEmpleado()
        {
            _calculadora = new CalculadoraSalario();
        }

        public void Generar(Empleado empleado)
        {
            Console.WriteLine($"=== REPORTE ===");
            Console.WriteLine($"Nombre: {empleado.Nombre}");
            Console.WriteLine($"Salario Neto: {_calculadora.CalcularSalarioNeto(empleado)}");
        }
    }
}
