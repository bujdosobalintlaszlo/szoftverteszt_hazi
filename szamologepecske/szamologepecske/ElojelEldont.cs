using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamologepecske
{
    class ElojelEldont
    {
        string szam;
        public ElojelEldont(string szam)
        {
            this.szam = szam;
        }
        public bool EloEldont()
        {
            return Elojele(szam);
        }
        private bool Elojele(string s)
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
    }
}
