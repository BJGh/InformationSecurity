using System;


namespace DiffieHellman
{
    sealed class Person
    {
        private string name;
        private int g;
        private int p;
        private int publickey;


        public string Name
        {
            get { return this.name; }
            set { name = value; }
        }
        public int G
        {
            get { return g; }
            set { g = value; }
        }
        public int P
        {
            get { return p; }
            set { p = value; }
        }
        public int publicKey()
        {
            publickey = generateNumber();
            return publickey;
        }

        public int generateNumber()
        {
            var rand = new Random();
           return rand.Next(0,100);
        }

        public int generatePrivatekey()
        {
            return (int) (Math.Pow(g, publickey)) % p;
        }
        public int personKey(int keyExchange,int publickey)
        {
            int keyfinal = (int)(Math.Pow(keyExchange, publickey)) % p;
            return keyfinal;
        }

    }
}
