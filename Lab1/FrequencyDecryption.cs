using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace CaesarCipher
{
	class FrequencyDecryption
	{//Монограмная замена: сопоставляет 2 словаря открытого и зашифрованного текстов, и в зависимости от
	///наибольшей частоты, заменяет символы зашифрованного текста на соответсвующие символы из Monogram_d	
		
		private Dictionary<char, double> normalFrequencyMonogram = new Dictionary<char, double>();//
		private Dictionary<char, double> encryptedFrequencyMonogram = new Dictionary<char, double>();
		private Dictionary<char, char> Monogram_d = new Dictionary<char, char>();
		private int countLetters;

		Dictionary<char, int> normalTextCountMonogram = new Dictionary<char, int>() {
			 {'а',0},{'б',0},{'в',0},{'г',0},{'д',0},{'е',0},
			{'ё',0},{'ж',0},{'з',0},{'и',0},{'й',0},{'к',0},{'л',0},
			{'м',0},{'н',0},{'о',0},{'п',0},{'р',0},{'с',0},{'т',0},
			{'у',0},{'ф',0},{'х',0},{'ц',0},{'ч',0},{'ш',0},{'щ',0},
			{'ъ',0},{'ы',0},{'ь',0},{'э',0},{'ю',0},{'я',0}
				};
		Dictionary<char, int> encryptedTextCountMonogram = new Dictionary<char, int>() {
			 {'а',0},{'б',0},{'в',0},{'г',0},{'д',0},{'е',0},
			{'ё',0},{'ж',0},{'з',0},{'и',0},{'й',0},{'к',0},{'л',0},
			{'м',0},{'н',0},{'о',0},{'п',0},{'р',0},{'с',0},{'т',0},
			{'у',0},{'ф',0},{'х',0},{'ц',0},{'ч',0},{'ш',0},{'щ',0},
			{'ъ',0},{'ы',0},{'ь',0},{'э',0},{'ю',0},{'я',0}
				};


		private double valueFrequency(int lettercount, int letter)
		{
		 return	Math.Round(((double)letter / (double)lettercount), 4);
		}
		public void saveFrequencies()
        {
			encryptedFrequencyMonogram = encryptedFrequencyMonogram.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
			normalFrequencyMonogram = normalFrequencyMonogram.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
	
			List<char> normalList = new List<char>(this.normalFrequencyMonogram.Keys);
			List<char> encryptedList = new List<char>(this.encryptedFrequencyMonogram.Keys);

			Monogram_d = normalList.Zip(encryptedList, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
			Console.WriteLine("Создан словарь монограм.");
		}

		public void countFrequencyOpenText()
		{
			StreamReader sr = new StreamReader("texts/chapter1.txt");
		
			List<char> lines = new List<char>();
			while(!sr.EndOfStream)
            {
				string line = sr.ReadLine();
				line.Replace(" ", "");
				line.Replace("\\p{P}+", "");

				lines.AddRange(line);
            }
			sr.Close();
		foreach (char ch in lines)
            {
				if (char.IsWhiteSpace(ch) || char.IsDigit(ch) || char.IsPunctuation(ch) || char.IsSeparator(ch))
				{
					continue;
				}
                else
				{
					++countLetters;
					normalTextCountMonogram[char.ToLower(ch)]++;
				}

            }

		foreach(var chDictionary in normalTextCountMonogram.Keys)
            {
				if(normalTextCountMonogram[chDictionary]!=0)
                {
					double letterfrequency = Math.Round(valueFrequency(countLetters, normalTextCountMonogram[chDictionary]),4);
					normalFrequencyMonogram.Add(chDictionary, letterfrequency);
                }
            }
		
		}

		public void countFrequencyEncryptedlText()
		{
			StreamReader sr = new StreamReader("texts/caesarencrypt.txt");

			List<char> lines = new List<char>();
			while (!sr.EndOfStream)
			{
				string line = sr.ReadLine();
				line.Replace(" ", "");
				line.Replace("\\p{P}+", "");
				lines.AddRange(line);
			}
			sr.Close();
			foreach (char ch in lines)
			{
				if (char.IsWhiteSpace(ch) || char.IsDigit(ch) || char.IsPunctuation(ch) || char.IsSeparator(ch))
				{
					continue;
				}
				else
				{
					++countLetters;
					encryptedTextCountMonogram[char.ToLower(ch)]++;
				}
			}

			foreach (var chDictionary in encryptedTextCountMonogram.Keys)
			{
				if (encryptedTextCountMonogram[chDictionary] != 0)
				{
					double letterfrequency = Math.Round(valueFrequency(countLetters, encryptedTextCountMonogram[chDictionary]), 4);
					encryptedFrequencyMonogram.Add(chDictionary, letterfrequency);
				}
			}//подсчет частоты букв в зашифрованном тексте
			sr.Close();

		}
		public void crackTextMonogram()
		{
			FileProcessor fp = new FileProcessor();
			string res = "";


			StreamReader reader = new StreamReader("texts/caesarencrypt.txt");
			List<char> characters = new List<char>();
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();


				characters.AddRange(line);

			}
			foreach (char ech in characters)
			{
				if (char.IsWhiteSpace(ech) || char.IsDigit(ech) || char.IsPunctuation(ech) || char.IsSeparator(ech))
				{
					res += ech;
				}
				else
				{

					res += Monogram_d[char.ToLower(ech)];


				}
			}
			writeFileDecryptionMonogram(res);
			

		}

		public void writeFileDecryptionMonogram(string v)
		{
			string fileName = "texts/monogram.txt";
			var Writer = new StreamWriter(fileName, true);
			Writer.WriteLine(v);
			Writer.Close();
		}

	}
}
