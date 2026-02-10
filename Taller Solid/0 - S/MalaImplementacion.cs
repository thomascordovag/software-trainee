// Mala implementación del Principio de Responsabilidad Única (Single Responsibility Principle)
// Esta clase tiene múltiples responsabilidades

namespace TallerSolid.S.Bad
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public decimal Salario { get; set; }

        // Responsabilidad 1: Cálculo de salario
        public decimal CalcularSalarioNeto()
        {
            return Salario * 0.85m; // Descuento de impuestos
        }

        // Responsabilidad 2: Guardado en base de datos
        public void GuardarEnBaseDatos()
        {
            Console.WriteLine($"Guardando empleado {Nombre} en la base de datos");
        }

        // Responsabilidad 3: Generación de reportes
        public void GenerarReporte()
        {
            Console.WriteLine($"=== REPORTE ===");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Salario Neto: {CalcularSalarioNeto()}");
        }
    }
}
