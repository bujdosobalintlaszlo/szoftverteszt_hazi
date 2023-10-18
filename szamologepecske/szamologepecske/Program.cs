using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamologepecske
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Osszeadas o = new Osszeadas("","");
            string ki = o.Kiszamol();
            Console.WriteLine(ki);
            Console.ReadKey();
        }
    }
}
