//-----------------------------------------------------
//# Mukodo Valtozat 1.0 #
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
            bool rightPlace = true;

            if (rtömb[roszlop] == 0)
            {
                rightPlace = false;
            }

            else
            {
                int mostaniOszlop = 0;
                while ((mostaniOszlop < roszlop) && (rtömb[mostaniOszlop] != rtömb[roszlop]) && (Math.Abs(roszlop - mostaniOszlop) != Math.Abs(rtömb[roszlop] - rtömb[mostaniOszlop]) && (rtömb[roszlop] <= 8)))
                {
                    mostaniOszlop++;
                }

                if (mostaniOszlop < roszlop)
                {
                    rightPlace = false;
                }
            }

            return rightPlace;
        }

        static void Main(string[] args)
        {
            int n = 8;
            int[] table = new int[n];

            for (int i = 0; i < table.Count(); i++)
            {
                table[i] = 0;
            }

            int oszlop = 0;
            while ((oszlop >= 0) && (oszlop <= 8))
            {
                if (!isRight(table, oszlop))
                {
                    if (table[oszlop] >= 8)
                    {
                        table[oszlop] = 0;
                        oszlop--;
                        table[oszlop]++;
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

    			if (table[oszlop] == 8)
        		{
	 				Kiiratas(table);
	           	 	oszlop--;
		 			table[oszlop] ++;
	            }
            }
            Console.ReadKey();
        }
    }
}
