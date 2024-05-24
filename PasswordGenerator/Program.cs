using System;

namespace PasswordGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PasswordGenerator passwordGenerator = new PasswordGenerator();

            string password = passwordGenerator.GeneratePassword(12, true, true, true);
            Console.WriteLine("Senha gerada: " + password);
        }
    }
}



