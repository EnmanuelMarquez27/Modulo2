using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese su fecha de nacimiento (formato: dd/mm/aaaa):");
        string input = Console.ReadLine();

        try
        {
            DateTime fechaNacimiento = DateTime.ParseExact(input, "dd/MM/yyyy", null);
            string diaSemana = fechaNacimiento.ToString("dddd");

            Console.WriteLine($"Naciste un día {diaSemana}.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Formato de fecha inválido. Por favor, use el formato dd/mm/aaaa.");
        }
    }
}
