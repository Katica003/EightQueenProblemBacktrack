using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtrack
{
    class Program
    {
        static void Kiiratas(int[] ktömb)
        {
            for (int i = 0; i < ktömb.Count(); i++)
            {
                Console.Write(ktömb[i]);
            }
            Console.WriteLine();
        }
        static bool isRight(int[] rtömb, int roszlop)
        {
            bool w = true;
          
            if (rtömb[roszlop] == 0)
            {
                w = false;
            }

            else
            { 
                int xo = 0;
                while ((xo < roszlop) && (rtömb[xo] != rtömb[roszlop]) | (Math.Abs(roszlop - xo) != Math.Abs(rtömb[roszlop] - rtömb[xo])))
                {
                     xo++;
                }
                
                if (xo < roszlop)
                {
                    w = false;
                }
             }
            
             return w;
        }

        static void Main(string[] args)
        {
            int n = 8;
            int[] table = new int [n];

            for (int i = 0; i < table.Count(); i++)
			{
                table[i] = 0;
            }
            
            Kiiratas(table);
         
            int oszlop = 0;
            while ((oszlop >= 0) & (oszlop < 8))
            {
                if (!isRight(table, oszlop))
                {
                         if (table[oszlop] == 8)
                         {
                              table[oszlop] = 0;
                              oszlop--;
                         }
                         else
                         {
                             table[oszlop]++;
                         }
                }

                else
                {
                    oszlop++;
                } 
            }

            Kiiratas(table);

            Console.ReadKey();
        }

     }
}
