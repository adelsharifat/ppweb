using System;
using static ProjectProgress.Utils.AppHelpers;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BCrypt.Hash("123"));
            Console.ReadKey();
        }
    }
}
