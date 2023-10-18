using szamologepecske;

class MuveletElvegzes
{
    string a;
    string b;
    int sz;

    public string A { get { return a; } }
    public string B { get { return b; } }
    public int Sz { get { return sz; } }

    public MuveletElvegzes(string a, string b, int sz)
    {
        this.a = a;
        this.b = b;
        this.sz = sz;
    }

    public string Vege()
    {
        return Szamol();
    }

    public string Szamol()
    {
        if (sz == 0)
        {
            Osszead osszeado = new Osszead(a, b, sz);
            return osszeado.Elvegez();
        }
        else if (sz == 1)
        {
            Osszead osszeado = new Osszead(a, b, sz);
            return osszeado.Elvegez();
        }
        else
        {
            Osszead osszeado = new Osszead(a, b, sz);
            return osszeado.Elvegez();
        }
    }
}
