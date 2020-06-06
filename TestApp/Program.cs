using Andaluh;
using System;

namespace TestApp
{
    public class Program
    {
        static void Main(string[] args) 
        {
            string result;
            if (args.Length == 0)
                result = "Para probar la funcionalidad especifica dotnet run \"Texto a transcribir\"";
            else
                result = args[0].ToAndaluh();

            Console.Write("Transcripción => ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(result);
            Console.ResetColor();
        }
    }
}
