using System;
using System.Numerics;
namespace RSA
{
    class RSA
    {
       public  int genenerateP(int x, int y)
        {
            int P = (x - 1) * (y - 1);
            int e = 17;
            Random rnd = new Random();
            while (!((iscoprime(e, P) && issimple(e))))
            {
                e = rnd.Next(1, 20);
            }
            return e;
        }
      public  int encrypt_RSA(int key, int e, int x, int y)
        {


            BigInteger n = x * y;
            int phi = (x - 1) * (y - 1);
            BigInteger nkey = BigInteger.Pow(key, e);
            nkey = BigInteger.Remainder(nkey, n);
            return (int)nkey;


        }

     public   int decrypt_RSA(int key, int e, int x, int y)
        {

            int d = 2;


            BigInteger n = x * y;
            BigInteger phi = (x - 1) * (y - 1);

            Random rnd = new Random();

            while ((d * e % phi) != 1)
            {
                d = rnd.Next(1, 5000);
            }
            Console.Write("Secret key ");
            Console.WriteLine(d);
            BigInteger nkey = BigInteger.Pow(key, d);
            nkey = BigInteger.Remainder(nkey, n);
            return (int)nkey;

        }
      private  bool iscoprime(int a, int b)
        {
            for (int i = 2; i < a; i++)
            {
                if ((a % i == 0) && (b % i == 0))
                {
                    return false;
                }
            }
            return true;

        }
     private  bool issimple(int a)
        {
            for (int i = 2; i < a; i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;

        }
    }
}
