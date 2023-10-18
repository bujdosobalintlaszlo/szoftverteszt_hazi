using System.Text;
using System;
using System.Collections.Generic;

class Osszead
{
    string a;
    string b;
    int sz;

    public string A { get { return a; } }
    public string B { get { return b; } }
    public int Sz { get { return sz; } }

    public Osszead(string a, string b, int sz)
    {
        this.a = a;
        this.b = b;
        this.sz = sz;
    }

    public string Elvegez()
    {
        return Muvelet(a, b);
    }
    public static string NullaTorol(string str)
    {
        int startIndex = 0;

        while (str[startIndex] == '0')
        {
            startIndex++;
        }
        return startIndex == str.Length ? "0" : str.Substring(startIndex);


    }
    public string Muvelet(string a, string b)
    {
        if (sz == 0)
        {
            int maxiHosszi = Math.Max(a.Length, b.Length);
            int maradek = 0;
            StringBuilder eredmeny = new StringBuilder(maxiHosszi + 1);
            for (int i = 0; i < maxiHosszi; i++)
            {
                int szam1 = i < a.Length ? a[a.Length - 1 - i] - '0' : 0;
                int szam2 = i < b.Length ? b[b.Length - 1 - i] - '0' : 0;

                int sum = szam1 + szam2 + maradek;
                maradek = sum / 10;
                eredmeny.Insert(0, (char)(sum % 10 + '0'));
            }
            if (maradek > 0)
            {
                eredmeny.Insert(0, (char)(maradek + '0'));
            }
            return eredmeny.ToString();
        }

        else if (sz == 1)
        {
            a = a.Substring(1);
            b = b.Substring(1);
            int maxiHosszi = Math.Max(a.Length, b.Length);
            int maradek = 0;
            StringBuilder eredmeny = new StringBuilder(maxiHosszi + 1);
            for (int i = 0; i < maxiHosszi; i++)
            {
                int szam1 = i < a.Length ? a[a.Length - 1 - i] - '0' : 0;
                int szam2 = i < b.Length ? b[b.Length - 1 - i] - '0' : 0;
                int sum = szam1 + szam2 + maradek;
                maradek = sum / 10;
                eredmeny.Insert(0, (char)(sum % 10 + '0'));
            }
            if (maradek > 0)
            {
                eredmeny.Insert(0, (char)(maradek + '0'));
            }
            return "-" + eredmeny.ToString();
        }
        else
        {
            bool aNegvNem = a[0] == '-';
            bool bNegvNem = b[0] == '-';

            a = aNegvNem ? a.Substring(1) : a;
            b = bNegvNem ? b.Substring(1) : b;

            bool elsoNagyobb = NagyobbEVagyMiAManocska(a, b);
            a = '0' + a;
            b = '0' + b;
            if (!elsoNagyobb)
            {
                string temp = a;
                a = b;
                b = temp;
            }

            string eredmeny = ActuallyGenuenlyKivonomTesomsz(a, b);

            if (!elsoNagyobb)
            {
                eredmeny = "-" + NullaTorol(eredmeny);
            }
            if (eredmeny == "0")
            {
                return eredmeny;
            }
            else
            {
                bool oNulla = true;
                foreach (char c in eredmeny)
                {
                    if (c != '0')
                    {
                        oNulla = false;
                        break;
                    }
                }

                if (oNulla)
                {
                    return eredmeny[0].ToString();
                }
            }
            
            return NullaTorol(eredmeny);
        }
    }
    private static bool NagyobbEVagyMiAManocska(string a, string b)
    {
        if (a.Length > b.Length)
            return true;
        if (a.Length < b.Length)
            return false;

        for (int i = 0; i < a.Length; i++)
        {
            int Szamj1 = a[i] - '0';
            int Szamj2 = b[i] - '0';

            if (Szamj1 > Szamj2)
                return true;
            else if (Szamj1 < Szamj2)
                return false;
        }

        return true;
    }
    private static string ActuallyGenuenlyKivonomTesomsz(string a, string b)
    {
        int maxHossz = Math.Max(a.Length, b.Length);
        char[] eredmeny = new char[maxHossz];

        int maradek = 0;
        for (int i = 0; i < maxHossz; i++)
        {
            int Szamj1 = i < a.Length ? a[a.Length - 1 - i] - '0' : 0;
            int Szamj2 = i < b.Length ? b[b.Length - 1 - i] - '0' : 0;

            int kulonbseg = Szamj1 - Szamj2 - maradek;

            if (kulonbseg < 0)
            {
                kulonbseg += 10;
                maradek = 1;
            }
            else
            {
                maradek = 0;
            }

            eredmeny[maxHossz - 1 - i] = (char)(kulonbseg + '0');
        }

        int startIndex = maradek == 1 ? 0 : 1;
        return new string(eredmeny, startIndex, maxHossz - startIndex);
    }

}