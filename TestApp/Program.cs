using Andaluh;
using System;

namespace TestApp
{
    public class Program
    {
        static void Main() 
        {
            var result = "Esto es una prueba de transcripción con el modo debug activo para ver cómo va cambiando la frase cada regla".ToAndaluh();
            Console.WriteLine("------------------RESULT=>" + result);
        }
    }
}
