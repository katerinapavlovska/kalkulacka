using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace kalkulacka2
{
    class Operace
    {
        
       

       public static int faktorial (int cislo)
        {
            int vysledek = 1;
            if (cislo < 0) { vysledek = -1;}
            else
            {
                for (int i = 2; i<=cislo; i++)
                {
                    vysledek *= i;
                }
            }
            return vysledek;
        }

        public static double mocnina (double zaklad, double exponent)
        {
            return Math.Pow(zaklad, exponent);
        }
    }
}

