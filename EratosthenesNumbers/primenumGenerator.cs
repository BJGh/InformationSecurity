using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eratosthenes
{
    class primenumGenerator
    {
        private int n;
        public int Setget_n { get { return n; }set { n = value; } }
        public List<int> prime()
        {
             
            List<int> result = new List<int>();
            bool[] a = new bool[n];
            for (int i = 2; i < n; i++)
            {
                a[i] = true;
            }
            for (int i = 2; i * i < n; ++i)
            {
                if (a[i])
                {
                    for (int s = i * i; s < n; s += i)
                    {
                        a[s] = false;
                    }
                }
            }
            for (int w = 0; w < a.Length; w++)
            {
                if (a[w])
                { result.Add(w); }

            }
            return result;
        }
    }
}
