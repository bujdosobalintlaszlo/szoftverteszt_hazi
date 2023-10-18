using System;

namespace szamologepecske
{
    class Osszeadas
    {
        string a;
        string b;
        ValidE validator;
        ElojelEldont dontoa;
        ElojelEldont dontob;
        public int sz;
        public string A { get { return a; } }
        public string B { get { return b; } }
        public Osszeadas(string a, string b)
        {
            this.a = a;
            this.b = b;
            validator = new ValidE(a, b);
            dontoa = new ElojelEldont(a);
            dontob = new ElojelEldont(b);
        }
        public string Kiszamol()
        {
            if (validator.Eldont())
            {
                if (a == "0")
                {
                    return b;
                }
                else if (b == "0")
                {
                    return a;
                }
                else if (dontoa.EloEldont() && dontob.EloEldont())
                {
                    sz = 0;
                    return new MuveletElvegzes(a, b, sz).Szamol();
                }
                else if (!dontoa.EloEldont() && !dontob.EloEldont())
                {
                    sz = 1;
                    return new MuveletElvegzes(a, b, sz).Szamol();
                }
                else
                {
                    sz = 2;
                    return new MuveletElvegzes(a, b, sz).Szamol();
                }
            }
            else
            {
                return "HIBA";
            }
        }
    }
}