using System;

class Calculadora
{
    static void Main()
    {
        int opcion = 0;

        while (opcion != 6)
        {
            // Mostrar el menú
            Console.WriteLine("\n--- CALCULADORA ---");
            Console.WriteLine("1 - Suma");
            Console.WriteLine("2 - Resta");
            Console.WriteLine("3 - Multiplicación");
            Console.WriteLine("4 - División");
            Console.WriteLine("5 - Elevar un número a la potencia");
            Console.WriteLine("6 - Salir");
            Console.Write("Seleccione una opción (1-6): ");

            // Leer la opción
            string entrada = Console.ReadLine();
            if (!int.TryParse(entrada, out opcion))
            {
                Console.WriteLine("Entrada inválida. Intente de nuevo.");
                continue;
            }

            // Validar salida
            if (opcion == 6)
            {
                Console.WriteLine("¡Saliendo de la calculadora!");
                break;
            }

            // Validar opción válida
            if (opcion < 1 || opcion > 6)
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
                continue;
            }

            // Pedir los dos números
            Console.Write("Ingrese el primer número: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese el segundo número: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            // Operaciones
            switch (opcion)
            {
                case 1:
                    Console.WriteLine($"Resultado: {num1} + {num2} = {num1 + num2}");
                    break;

                case 2:
                    Console.WriteLine($"Resultado: {num1} - {num2} = {num1 - num2}");
                    break;

                case 3:
                    Console.WriteLine($"Resultado: {num1} * {num2} = {num1 * num2}");
                    break;

                case 4:
                    if (num2 != 0)
                        Console.WriteLine($"Resultado: {num1} / {num2} = {num1 / num2}");
                    else
                        Console.WriteLine("¡Error! No se puede dividir por cero.");
                    break;

                case 5:
                    double potencia = Math.Pow(num1, num2);
                    Console.WriteLine($"Resultado: {num1} elevado a {num2} = {potencia}");
                    break;
            }
        }
    }
}
