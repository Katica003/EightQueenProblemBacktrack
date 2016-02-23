using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtrack
{
    class Program
    {
        static void KiiratasTömb(int[] ktömb)
        {
            for (int i = 0; i < ktömb.Count(); i++)
            {
                Console.Write(ktömb[i]);
            }
            Console.WriteLine();
        }

        static void KiiratasList(List<int[]> kList)
        {

            for (int i = 0; i < kList.Count; i++)
            {
                KiiratasTömb(kList[i]);
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

        static bool isAllEight(int[] table)
        {
            bool result = true;

            for (int i = 0; i < 8; i++)
            {
                if (table[i] != 8)
                {
                    result = false;
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            int n = 8;
            int[] table = new int[n];
            List<int[]> Solutions = new List<int[]>();
            int[] elforgatottFelallasFirst = new int[n];
            int[] elforgatottFelallasSecond = new int[n];
            int[] elforgatottFelallasThird = new int[n];
            int[] mirror = new int[n];
            int[] mirror1 = new int[n];
            int[] mirror2 = new int[n];
            int[] mirror3 = new int[n];

            for (int i = 0; i < table.Count(); i++)
            {
                table[i] = 0;
            }

            int oszlop = 0;
            while ((oszlop >= 0) && (table[0] <= 8))
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

                if (oszlop == 8)
                {
                    Solutions.Add((int[])table.Clone());
                    oszlop--;
                    table[oszlop]++;
                }
            }

            for (int l = 0; l < Solutions.Count; l++)
            {
                for (int k = 0; k < 8; k++)
                {
                    mirror[7 - k] = Solutions[l][k];
                }
                for (int k = 0; k < 8; k++)
                {
                    elforgatottFelallasFirst[8 - Solutions[l][k]] = k + 1;
                }
                for (int k = 0; k < 8; k++)
                {
                    mirror1[7 - k] = elforgatottFelallasFirst[k];
                }

                for (int k = 0; k < 8; k++)
                {
                    elforgatottFelallasSecond[8 - elforgatottFelallasFirst[k]] = k + 1;
                }
                for (int k = 0; k < 8; k++)
                {
                    mirror2[7 - k] = elforgatottFelallasSecond[k];
                }
                for (int k = 0; k < 8; k++)
                {
                    elforgatottFelallasThird[8 - elforgatottFelallasSecond[k]] = k + 1;
                }
                for (int k = 0; k < 8; k++)
                {
                    mirror3[7 - k] = elforgatottFelallasThird[k];
                }



                for (int i = 0; i < Solutions.Count; i++)
                {
                    if (i != l && Enumerable.SequenceEqual(elforgatottFelallasFirst, Solutions[i]))
                    {
                        Solutions.Remove(Solutions[i]);
                    }
                }
                for (int i = 0; i < Solutions.Count; i++)
                {
                    if (i != l && Enumerable.SequenceEqual(elforgatottFelallasSecond, Solutions[i]))
                    {
                        Solutions.Remove(Solutions[i]);
                    }
                }
                for (int i = 0; i < Solutions.Count; i++)
                {
                    if (i != l && Enumerable.SequenceEqual(elforgatottFelallasThird, Solutions[i]))
                    {
                        Solutions.Remove(Solutions[i]);
                    }
                }

                for (int i = 0; i < Solutions.Count; i++)
                {
                    if (i != l && Enumerable.SequenceEqual(mirror, Solutions[i]))
                    {
                        Solutions.Remove(Solutions[i]);
                    }
                }
                for (int i = 0; i < Solutions.Count; i++)
                {
                    if (i != l && Enumerable.SequenceEqual(mirror1, Solutions[i]))
                    {
                        Solutions.Remove(Solutions[i]);
                    }
                }
                for (int i = 0; i < Solutions.Count; i++)
                {
                    if (i != l && Enumerable.SequenceEqual(mirror2, Solutions[i]))
                    {
                        Solutions.Remove(Solutions[i]);
                    }
                }
                for (int i = 0; i < Solutions.Count; i++)
                {
                    if (i != l && Enumerable.SequenceEqual(mirror3, Solutions[i]))
                    {
                        Solutions.Remove(Solutions[i]);
                    }
                }
            }
            Console.WriteLine("---------");
            KiiratasList(Solutions);
            Console.WriteLine("---------");
            Console.WriteLine(Solutions.Count);
            Console.WriteLine("---------");

            Console.ReadKey();
        }

    }
}
