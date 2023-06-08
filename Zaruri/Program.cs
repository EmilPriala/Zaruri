﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace Zaruri
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] s = new int[n];
            Zaruri(0, n, s);
            Console.ReadKey();
        }

        static void Zaruri(int k, int n, int[] s) //combinatii posibile zaruri -> cate foruri/ p(val max a for)
        {
            if (k >= n)
            {
                for (int i = 0; i < n; i++)
                    Console.Write(s[i] + " ");
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i <= 5; i++)
                {
                    s[k] = i + 1;
                    Zaruri(k + 1, n, s);
                }
            }
        }
        static void permutari(int k, int n, int[] s, bool[] b)
        {
            if (k >= n)
            {
                for (int i = 0; i < n; i++)
                    Console.Write(s[i] + " ");
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!b[i])
                    {
                        b[i] = true;
                        s[k] = i;
                        permutari(k + 1, n, s, b);
                        b[i] = false;
                    }

                }
            }
        }
        /* se dau n dame(sah) si trebuie introduse pe o tabla de "sah" n * n astfel incat sa nu se intersecteze
         * cate solutii se dau? */

        static void bk(int k, int n, int[] s, bool[] b)
        {
            if (k >= n)
            {
                bool ok = true;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = i; j < n; j++)
                    {
                        if (Math.Abs(i - j) == Math.Abs(s[i] - s[j]))
                        {
                            ok = false;
                            break;
                        }
                    }
                }
                if (ok)
                {
                    for (int i = 0; i < n; i++)
                        Console.WriteLine(s[i] + " ");
                    Console.WriteLine();
                }

            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!b[i])
                    {
                        b[i] = true;
                        s[k] = i;
                        bk(k + 1, n, s, b);
                        b[i] = false;
                    }
                }

            }
        }
        static void aranjamente(int k, int n, int[] s, bool[] b, int p)
        {
            if (k >= p)
            {
                for (int i = 0; i < p; i++)
                    Console.WriteLine(s[i] + " ");
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!b[i])
                    {
                        b[i] = true;
                        s[k] = i;
                        aranjamente(k + 1, n, s, b, p);
                        b[i] = false;
                    }
                }
            }
        }
        static void combinari(int k, int n, int[] s, bool[] b, int p)
        {
            if (k >= p)
            {
                bool ok =true;
                for (int i = 0; i < p; i++)
                {
                    if (s[i] > s[i + 1])
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    for (int i = 0; i < p; i++)
                    {
                        Console.WriteLine(s[i] + " ");
                    }
                }
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!b[i])
                    {
                        b[i] = true;
                        s[k] = i;
                        combinari(k + 1, n, s, b, p);
                        b[i] = false;
                    }
                }
                
            }
        }
        static void combinari_eficiente(int k, int n, int[] s, int p)
        {
            if (k >= p)
            {
                for (int i = 1; i <= p; i++)
                    Console.WriteLine(s[i] + " ");
                Console.WriteLine();
            }
            else
            {
                for (int i = s[k - 1] + 1; i < n; i++)
                {
                    s[k] = i;
                    combinari_eficiente(k + 1, n, s, p);
                }
            }
        }
        static void egal_patratMagic(int k, int n, int[] s, bool[] b)
        {
            if(k >= n)
            {
                int sl1 = s[0] + s[1] + s[2];
                int sl2 = s[3] + s[4] + s[5];
                int sl3 = s[6] + s[7] + s[8];

                int sc1 = s[0] + s[3] + s[6];
                int sc2 = s[1] + s[4] + s[7];
                int sc3 = s[2] + s[5] + s[8];

                int sd1 = s[0] + s[1] + s[8];
                int sd2 = s[2] + s[4] + s[6];

                if(sl1 == sl2 && sl1 == sl3 && sl1 == sc1 && sl1 == sc2 && sl1 == sd1 && sl1 == sd2)
                {
                    for (int i = 0; i <= 9; i++)
                        Console.WriteLine(s[i] + " ");
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!b[i])
                    {
                        b[i] = true;
                        s[k] = i;
                        egal_patratMagic(k + 1, n, s, b, p);
                        b[i] = false;
                    }
                }
            }
        }
    }
}
