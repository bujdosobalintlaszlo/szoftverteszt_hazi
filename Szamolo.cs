using System;
using System.Linq;
using System.Text;
namespace TeljesSzamolo
{
    public class Szamolo
    {
        private string a;
        private string b;
        private static int sz;
        public string A { get { return a; } }
        public string B { get { return b; } }
        public Szamolo(string a, string b)
        {
            this.a = a;
            this.b = b;
        }
        public string Kiszamol()
        {
            if (Eldont(a) && Eldont(b))
            {
                if (a == "0")
                {
                    return b;
                }
                else if (b == "0")
                {
                    return a;
                }
                else if (ElojelEldont(a) && ElojelEldont(b))
                {
                    sz = 0;
                    return Elvegez(a, b, sz);
                }
                else if (!ElojelEldont(a) && !ElojelEldont(b))
                {
                    sz = 1;
                    return Elvegez(a, b, sz);
                }
                else
                {
                    sz = 2;
                    return Elvegez(a, b, sz);
                }
            }
            else
            {
                return "HIBA";
            }
        }
        private bool Eldont(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;

            if (s[0] == '-')
            {
                if (s.Length == 1 || s[1] == '0') return false;
                return s.Substring(1).All(c => char.IsDigit(c));
            }
            else
            {
                return !(s.Length > 1 && s[0] == '0' || !char.IsDigit(s[0])) && !s.Any(c => !char.IsDigit(c));
            }
        }
        private bool ElojelEldont(string s)
        {
            if (s.StartsWith("-"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private static string NullaTorol(string str)
        {
            int startIndex = 0;

            while (str[startIndex] == '0')
            {
                startIndex++;
            }
            return startIndex == str.Length ? "0" : str.Substring(startIndex);
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
        private string Elvegez(string a, string b, int sz)
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
                string tempA = a;
                string tempB = b;
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
                if (eredmeny == "0")
                {
                    return eredmeny;
                }
                if (eredmeny.Length > 1 && eredmeny.StartsWith("0"))
                {
                    return eredmeny[0].ToString();
                }
                if (elsoNagyobb && tempA.StartsWith("-"))
                {
                    eredmeny = "-" + NullaTorol(eredmeny);
                }
                if (!elsoNagyobb && tempB.StartsWith("-"))
                {
                    eredmeny = "-" + NullaTorol(eredmeny);
                }
                return NullaTorol(eredmeny);
            }
        }
    }
}
