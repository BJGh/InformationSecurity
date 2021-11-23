using System;

namespace DiffieHellman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Диффи-Хеллман");

            Person Alice = new Person();
            Person Bob = new Person();
            var rnd = new Random();
            int G = rnd.Next(0, 100);
            int P = rnd.Next(0, 100);

            Alice.G = G;
            Alice.P = P;
            Bob.G = G;
            Bob.P = P;
            
            Console.WriteLine("Публичный \tG=" + G);
            Console.WriteLine("Публичный \tP=" + P);
            int Alice_public = Alice.publicKey();
            int Bob_public = Bob.publicKey();
            Console.WriteLine("Публичный ключ\tАлисы=" + Alice_public);
            Console.WriteLine("Публичный ключ \tБоба=" + Bob_public);

            int Alice_key = Alice.generatePrivatekey();
            int Bob_key = Bob.generatePrivatekey();
            Console.WriteLine("Приватный ключ \tАлисы=" + Alice_key);
            Console.WriteLine("Приватный ключ \tБоба=" + Bob_key);

            int sync_key_A = Alice.personKey(Bob_key, Alice_public);
            int sync_key_B = Bob.personKey(Alice_key, Bob_public);
            if (sync_key_A == sync_key_B)
            {
                Console.WriteLine("Симметричный приватный ключ сгенерирован");
                Console.WriteLine(sync_key_A + "=" + sync_key_B);
            }
            //дело в том, что необходимо использовать собственный конструктор целых чисел
            //в строготипизированном языке
            //иначе теряется точность при конвертировании с типа double в int.
        }
    }
}
