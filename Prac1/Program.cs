using System;

namespace Prac1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            bool p = true;
            Cipher c = new Cipher();
            while (p)
            {
                Console.WriteLine("1 - Шифр Цезаря");
                Console.WriteLine("2 - Шифр Цезаря с ключевым словом");
                Console.WriteLine("3- Выйти");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        Console.WriteLine("Введите текст. После ввода нажмите ВВОД");
                        string text = Console.ReadLine();
                        Console.WriteLine("Введите число сдвига. После ввода нажмите ВВОД");
                        int k = Convert.ToInt32(Console.ReadLine());
                        string encrypted = c.Encrypt(text, k);
                        Console.WriteLine("Зашифрованный текст");
                        Console.WriteLine(encrypted);
                        string decrypted = c.Decrypt(encrypted, k);
                        Console.WriteLine("Дешифрованный текст");
                        Console.WriteLine(decrypted);
                        break;

                    case "2":
                        Console.Write("Введите ключевое слово: ");
                        string keyWord = Console.ReadLine().ToLower();
                        Console.Write("Ключ: ");
                        int shift = Convert.ToInt32(Console.ReadLine());

                    
                        Console.WriteLine();
                        Console.WriteLine();

                        string open = "", close = "";
                        Console.Write("Введите текст: ");
                        open = Console.ReadLine().ToLower();
                        close = c.EncryptWord(open,keyWord,shift);
                        Console.WriteLine();
                        Console.WriteLine("Зашифрованный алфавит: " + c.getNewAlphabet());
                        Console.WriteLine("Зашиифрованный текст" + close);
                        open = c.DecryptWord(close);
                        Console.WriteLine();
                        Console.WriteLine("Расшифрованное сообщение: " + open);

                        break;

                    case "3":
                        Console.WriteLine("Выход");
                        p = false;
                        break;

          
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }

            }
        }
    }
}
