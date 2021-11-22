using System;
using System.IO;

namespace CaesarCipher
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Шифр Цезаря");
			Console.WriteLine("Введите ключ");
			int k = Convert.ToInt32(Console.ReadLine());
			FileProcessor fp = new FileProcessor();
			//fp.Key = k;
			fp.readFileCrypted(k);
			Console.WriteLine("Текст зашифрован. Файл сохранен.");
			Console.WriteLine("Начало частотного анализа...");
			Console.WriteLine("Дешифровка текста с помощью монограмм..");

			FrequencyDecryption fd = new FrequencyDecryption();
			fd.countFrequencyOpenText();
			fd.countFrequencyEncryptedlText();
	
			fd.saveFrequencies();
			fd.crackTextMonogram();
			Console.WriteLine("Дешифровка текста монограммами завершена. Файл сохранен.");
		}
	}
}
