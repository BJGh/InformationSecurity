using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prac1
{
    class Cipher
    {
        private string alphabet = "абвгдеёжзийклмопрстуфхцшщъыьэюя";
        private char[] newalpha = new char[33];
        public  string getNewAlphabet()
        {
            string NewAlphabet = new string(newalpha);
            return NewAlphabet;
        }
        public string EncryptWord(string value, string word, int shift)
        {


            bool findSame = false;
            shift--;
            int d = 0, current = shift;
            // добавить ключевое слово в новый алфавит
            for (int i = shift; i < word.Length + shift; i++)
            {
                for (int j = shift; j < word.Length + shift; j++)
                {
                    if (word[i - shift] == newalpha[j])
                    {
                        findSame = true;
                        break;
                    }
                }
                if (!findSame)// если повторений нету, то буква добавляется в новый алфавит
                {
                    newalpha[current] = word[i - shift];
                    current++;
                }
                findSame = false;
            }

            // добавить буквы после ключевого слова
            for (int i = 0; i < alphabet.Length; i++)
            {
                for (int j = 0; j < newalpha.Length; j++)
                {
                    if (alphabet[i] == newalpha[j])
                    {
                        findSame = true;
                        break;
                    }
                }
                if (!findSame)
                {
                    newalpha[current] = alphabet[i];
                    current++;
                }
                findSame = false;
                if (current == newalpha.Length)
                {
                    d = i;
                    break;
                }
            }

            // добавить буквы после ключевого слова
            current = 0;
            for (int i = d; i < alphabet.Length; i++)
            {
                for (int j = 0; j < newalpha.Length; j++)
                {
                    if (alphabet[i] == newalpha[j])
                    {
                        findSame = true;
                        break;
                    }
                }
                if (!findSame)
                {
                    newalpha[current] = alphabet[i];
                    current++;
                }
                findSame = false;
            }
            string res = "";
            foreach (char ch in value)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (ch == alphabet[i])
                    {
                        res += newalpha[i];
                        break;
                    }
                }
            }
            return res;
        }

        public string DecryptWord(string value)
        {
            string decrypted = "";
            foreach (char ch in value)
            {
                for (int i = 0; i < newalpha.Length; i++)
                {
                    if (ch == newalpha[i])
                    {
                        decrypted += alphabet[i];
                        break;
                    }
                }
            }
            return decrypted;
        }

        public string Encrypt(string value, int shift)
        {


            shift %= 33;//prevent if shift large than >33
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                return new string(value);
            }
            char[] buffer = value.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {

                char letter = buffer[i];
                if (Convert.ToInt16(letter) + shift > 1103)
                {
                    letter = (char)(letter + shift - 32);
                }
                else
                { letter = (char)(letter + shift); }
                if (char.IsWhiteSpace(letter) || char.IsDigit(letter) || char.IsPunctuation(letter) || char.IsSeparator(letter))
                {
                    continue;
                }
                if (letter < 'А' && letter > 'Я')
                {
                    //letter = (char)(letter - 33);
                    letter = (char)((letter - 'А' + shift) % 33 + 'А');

                }
                else if (letter < 'а' && letter > 'я')
                {
                    //letter = (char)(letter + 33);
                    letter = (char)((letter - 'а' + shift) % 33 + 'а');
                }

                buffer[i] = letter;
            }
            return new string(buffer);
        }

        public string Decrypt(string value, int shift)
        {


            shift %= 33;//prevent if shift large than >33
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                return new string(value);
            }
            char[] buffer = value.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {

                char letter = buffer[i];
                if (Convert.ToInt16(letter) - shift > 1103)
                {
                    letter = (char)(letter - shift + 32);
                }
                else
                { letter = (char)(letter - shift); }
                if (char.IsWhiteSpace(letter) || char.IsDigit(letter) || char.IsPunctuation(letter) || char.IsSeparator(letter))
                {
                    continue;
                }
                if (letter < 'А' && letter > 'Я')
                {
                    //letter = (char)(letter - 33);
                    letter = (char)((letter - 'А' - shift) % 33 + 'А');

                }
                else if (letter < 'а' && letter > 'я')
                {
                    //letter = (char)(letter + 33);
                    letter = (char)((letter - 'а' - shift) % 33 + 'а');
                }

                buffer[i] = letter;
            }
            return new string(buffer);
        }


    }
}
