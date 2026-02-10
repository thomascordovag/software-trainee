using System;
using TallerSolid.S.MI;
using TallerSolid.S.BI;
using TallerSolid.O.MI;
using TallerSolid.O.BI;
using TallerSolid.L.MI;
using TallerSolid.L.BI;
using TallerSolid.I.MI;
using TallerSolid.I.BI;
using TallerSolid.D.MI;
using TallerSolid.D.BI;
// Programa principal creado por el asesor Copilot para ejecutar cada principio SOLID 
namespace TallerSolid
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                MostrarMenu("MENU PRINCIPAL", new[] {
                    "S - Single Responsibility Principle",
                    "O - Open/Closed Principle",
                    "L - Liskov Substitution Principle",
                    "I - Interface Segregation Principle",
                    "D - Dependency Inversion Principle",
                    "",
                    "6. Ejecutar todos los principios",
                    "0. Salir"
                });

                switch (Console.ReadLine())
                {
                    case "1": EjecutarPrincipio("SRP", EjecutarSRP_Mala, EjecutarSRP_Buena); break;
                    case "2": EjecutarPrincipio("OCP", EjecutarOCP_Mala, EjecutarOCP_Buena); break;
                    case "3": EjecutarPrincipio("LSP", EjecutarLSP_Mala, EjecutarLSP_Buena); break;
                    case "4": EjecutarPrincipio("ISP", EjecutarISP_Mala, EjecutarISP_Buena); break;
                    case "5": EjecutarPrincipio("DIP", EjecutarDIP_Mala, EjecutarDIP_Buena); break;
                    case "6": EjecutarTodos(); break;
                    case "0": Console.WriteLine("\n¡Hasta luego!"); return;
                    default: Console.WriteLine("\nOpción inválida.\n"); break;
                }
            }
        }

        static void MostrarMenu(string titulo, string[] opciones)
        {
            Console.Clear();
            Console.WriteLine($"\n========== {titulo} ==========\n");
            for (int i = 0; i < opciones.Length; i++)
                if (!string.IsNullOrEmpty(opciones[i]))
                    Console.WriteLine($"  {(i < opciones.Length - 2 ? (i + 1) + ". " : "")}{opciones[i]}");
            Console.Write("\nSeleccione una opción: ");
        }

        static void EjecutarPrincipio(string nombre, Action mala, Action buena)
        {
            MostrarMenu($"{nombre} - PRINCIPIO", new[] {
                "Mala Implementación",
                "Buena Implementación",
                "Comparar ambas",
                "0. Volver"
            });

            Console.Clear();
            switch (Console.ReadLine())
            {
                case "1": mala(); break;
                case "2": buena(); break;
                case "3": mala(); Console.WriteLine("\n" + new string('-', 60) + "\n"); buena(); break;
                case "0": return;
            }
            Console.WriteLine("\n\nPresione cualquier tecla..."); 
            Console.ReadKey();
        }

        static void EjecutarTodos()
        {
            Console.Clear();
            Console.WriteLine("\n========== EJECUTANDO TODOS LOS PRINCIPIOS SOLID ==========\n");
            
            Console.WriteLine("\n1. SRP"); EjecutarSRP_Buena();
            Console.WriteLine("\n2. OCP"); EjecutarOCP_Buena();
            Console.WriteLine("\n3. LSP"); EjecutarLSP_Buena();
            Console.WriteLine("\n4. ISP"); EjecutarISP_Buena();
            Console.WriteLine("\n5. DIP"); EjecutarDIP_Buena();
            
            Console.WriteLine("\n\n========== COMPLETADO ==========");
            Console.WriteLine("\n\nPresione cualquier tecla...");
            Console.ReadKey();
        }

        // ==================== SRP ====================
        static void EjecutarSRP_Mala()
        {
            Console.WriteLine("MALA IMPLEMENTACIÓN - SRP\nProblema: Una clase con múltiples responsabilidades\n");
            var emp = new TallerSolid.S.MI.Empleado { Nombre = "Juan", Salario = 3000m };
            Console.WriteLine($"Salario: ${emp.Salario} | Neto: ${emp.CalcularSalarioNeto()}");
            emp.GuardarEnBaseDatos();
            emp.GenerarReporte();
        }

        static void EjecutarSRP_Buena()
        {
            Console.WriteLine("BUENA IMPLEMENTACIÓN - SRP\nSolución: Cada clase con una responsabilidad\n");
            var emp = new TallerSolid.S.BI.Empleado { Nombre = "María", Salario = 3500m };
            Console.WriteLine($"Salario: ${emp.Salario} | Neto: ${new CalculadoraSalario().CalcularSalarioNeto(emp)}");
            new EmpleadoRepository().Guardar(emp);
            new ReporteEmpleado().Generar(emp);
        }

        // ==================== OCP ====================
        static void EjecutarOCP_Mala()
        {
            Console.WriteLine("MALA IMPLEMENTACIÓN - OCP\nProblema: Modificar clase para nuevos tipos\n");
            var calc = new TallerSolid.O.MI.CalculadoraBono();
            decimal salario = 2000m;
            Console.WriteLine($"Salario: ${salario}");
            Console.WriteLine($"Permanente: ${calc.CalcularBono(salario, TipoEmpleado.Permanente)}");
            Console.WriteLine($"Temporal: ${calc.CalcularBono(salario, TipoEmpleado.Temporal)}");
        }

        static void EjecutarOCP_Buena()
        {
            Console.WriteLine("BUENA IMPLEMENTACIÓN - OCP\nSolución: Extensión sin modificación\n");
            var calc = new TallerSolid.O.BI.CalculadoraBono();
            decimal salario = 2000m;
            Console.WriteLine($"Salario: ${salario}");
            Console.WriteLine($"Permanente: ${calc.Calcular(salario, new EmpleadoPermanente())}");
            Console.WriteLine($"Temporal: ${calc.Calcular(salario, new EmpleadoTemporal())}");
            Console.WriteLine($"Pasante: ${calc.Calcular(salario, new EmpleadoPasante())} (Nuevo!)");
        }

        // ==================== LSP ====================
        static void EjecutarLSP_Mala()
        {
            Console.WriteLine("MALA IMPLEMENTACIÓN - LSP\nProblema: Cuadrado no sustituye a Rectángulo\n");
            TallerSolid.L.MI.Rectangulo rect = new TallerSolid.L.MI.Cuadrado();
            rect.Ancho = 5; rect.Alto = 10;
            Console.WriteLine($"Ancho=5, Alto=10 | Área: {rect.CalcularArea()} (Esperado: 50)");
        }

        static void EjecutarLSP_Buena()
        {
            Console.WriteLine("BUENA IMPLEMENTACIÓN - LSP\nSolución: Abstracciones correctas\n");
            var rect = new TallerSolid.L.BI.Rectangulo { Ancho = 5, Alto = 10 };
            var cuad = new TallerSolid.L.BI.Cuadrado { Lado = 5 };
            Console.WriteLine($"Rectángulo: {rect.CalcularArea()}");
            Console.WriteLine($"Cuadrado: {cuad.CalcularArea()}");
        }

        // ==================== ISP ====================
        static void EjecutarISP_Mala()
        {
            Console.WriteLine("MALA IMPLEMENTACIÓN - ISP\nProblema: Interfaz grande obliga métodos innecesarios\n");
            var humano = new TallerSolid.I.MI.TrabajadorHumano();
            Console.WriteLine("Humano:"); humano.Trabajar(); humano.Comer();
            Console.WriteLine("\nRobot: (debe implementar Comer/Dormir pero lanza excepciones!)");
            new TallerSolid.I.MI.Robot().Trabajar();
        }

        static void EjecutarISP_Buena()
        {
            Console.WriteLine("BUENA IMPLEMENTACIÓN - ISP\nSolución: Interfaces específicas\n");
            var humano = new TallerSolid.I.BI.TrabajadorHumano();
            Console.WriteLine("Humano:"); humano.Trabajar(); humano.Comer();
            var robot = new TallerSolid.I.BI.Robot();
            Console.WriteLine("\nRobot (solo ITrabajable):"); robot.Trabajar();
        }

        // ==================== DIP ====================
        static void EjecutarDIP_Mala()
        {
            Console.WriteLine("MALA IMPLEMENTACIÓN - DIP\nProblema: Acoplamiento a implementación concreta\n");
            var service = new TallerSolid.D.MI.UsuarioService();
            service.CrearUsuario("Juan");
            Console.WriteLine("(Para cambiar BD hay que modificar código!)");
        }

        static void EjecutarDIP_Buena()
        {
            Console.WriteLine("BUENA IMPLEMENTACIÓN - DIP\nSolución: Depender de abstracciones\n");
            Console.WriteLine("MySQL:");
            new TallerSolid.D.BI.UsuarioService(new TallerSolid.D.BI.BaseDatosMySQL()).CrearUsuario("Juan");
            Console.WriteLine("\nPostgreSQL (sin modificar código!):");
            new TallerSolid.D.BI.UsuarioService(new TallerSolid.D.BI.BaseDatosPostgreSQL()).CrearUsuario("María");
        }
    }
}
