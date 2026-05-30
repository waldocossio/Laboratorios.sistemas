using System;

namespace EvaluacionFlujograma
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Cálculo Académico ===");
            Console.WriteLine("Estudiante: Waldo Cossio Cespedes\n");

            // 1. Solicitar información al usuario
            Console.Write("Por favor, ingrese el número de carnet de identidad: ");
            string entradaCarnet = Console.ReadLine();

            Console.Write("Por favor, ingrese el promedio original (0 - 100): ");
            string entradaPromedio = Console.ReadLine();

            // 2. Implementar validaciones
            if (ValidarEntradaEntero(entradaCarnet, out int carnet) &&
                ValidarEntradaDecimal(entradaPromedio, out double promedioOriginal))
            {
                // 3. Ejecutar el flujo lógico principal
                EjecutarLogicaPrincipal(carnet, promedioOriginal);
            }
            else
            {
                Console.WriteLine("\nError: Los datos ingresados no son válidos.");
                Console.WriteLine("Asegúrese de ingresar números correctos (sin letras ni símbolos especiales).");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        // Método para validar números enteros (Carnet)
        static bool ValidarEntradaEntero(string entrada, out int resultado)
        {
            return int.TryParse(entrada, out resultado);
        }

        // Método para validar números decimales (Promedio)
        static bool ValidarEntradaDecimal(string entrada, out double resultado)
        {
            return double.TryParse(entrada, out resultado);
        }

        // Método que concentra la lógica principal solicitada
        static void EjecutarLogicaPrincipal(int carnet, double promedioOriginal)
        {
            Console.WriteLine("\n--- Procesando Datos ---");

            // Extraer los últimos dos dígitos del carnet (usamos Math.Abs por si ingresan un número negativo)
            int ultimosDosDigitos = Math.Abs(carnet) % 100;

            // Calcular el bono (7%)
            double bono = ultimosDosDigitos * 0.07;

            // Calcular promedio final
            double promedioFinal = promedioOriginal + bono;

            // Obtener la clasificación académica
            string clasificacion = ObtenerClasificacion(promedioFinal);

            // Mostrar resultados claramente
            Console.WriteLine($"Promedio original:      {promedioOriginal:F2}");
            Console.WriteLine($"Bono calculado (7% de {ultimosDosDigitos:D2}): {bono:F2}");
            Console.WriteLine($"Promedio final:         {promedioFinal:F2}");
            Console.WriteLine($"Clasificación obtenida: {clasificacion}");
        }

        // Método dedicado a la regla de negocio de clasificación
        static string ObtenerClasificacion(double promedio)
        {
            // Puedes modificar estos rangos según la rúbrica exacta de tu universidad
            if (promedio >= 90)
            {
                return "Excelencia Académica";
            }
            else if (promedio >= 71)
            {
                return "Aprobado Pleno (Bueno)";
            }
            else if (promedio >= 51)
            {
                return "Aprobado (Suficiente)";
            }
            else
            {
                return "Reprobado";
            }
        }
    }
}