using System;
using System.Numerics;

namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            RSA rsa = new RSA();
            int message = 5;
            Console.Write("Message ");
            Console.WriteLine(message);

            int x = 61;

            int y = 53;

            int e = rsa.genenerateP(x, y);
            Console.Write("Открытый ключ ");
            Console.WriteLine(e);

            message = rsa.encrypt_RSA(message, e, x, y);
            Console.Write("Encrypted ");
            Console.WriteLine(message);

            int xb = rsa.decrypt_RSA(message, e, x, y);

            Console.Write("Decrypted ");


            Console.Write(xb);

        }


    }
    }
