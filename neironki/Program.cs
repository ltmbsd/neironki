using System;
using System.IO;

namespace neironki
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = insert();
            string[] xdblStr = binar(x);
            double[] y = function(x);
            string[] crsd = cross(xdblStr);

        }

        static int[] insert()
        {
            int[] x = new int[4];
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine("Введите числo " + (i + 1));
                x[i] = Convert.ToInt32(Console.ReadLine());
                if ((x[i] > 63) || (x[i] < 0))
                    i--;
            }
            return x;
        }

        static string[] binar(int[] x)
        {           
            int j = x.Length;
            int[] xdbl = new int[j];
            for (int i = 0; i < j; i++)
            {
                int x1 = x[i];
                int k = 0;
                xdbl[i] = 0;
                while (x1 > 1)
                {
                    if (x1 % 2 == 1)
                        xdbl[i] += (int)Math.Pow(10, k);
                    k++;
                    x1 /= 2;
                }
                xdbl[i] += (int)Math.Pow(10, k);
            }
            string[] xdblStr = new string[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                xdblStr[i] = Convert.ToString(xdbl[i]);
                while (xdblStr[i].Length < 6) xdblStr[i] = xdblStr[i].Insert(0, "0");
            }
            return xdblStr;
        }

        static double[] function(int[] x)
        {
            double[] y = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                x[i] -= 10;
                y[i] = 26 - (86 * x[i]) - (59 * x[i] * x[i]) + (3 * Math.Pow(x[i], 3));
            }
            
            return y;
        }

        static string[] cross(string[] xdblStr)
        {
            string[] xstr = new string[xdblStr.Length];
            int[] x = new int[xdblStr.Length];
            for (int i = 0; i < x.Length; i++)
                x[i] = Convert.ToInt32(xdblStr[i]);
            int[] x1 = x;
            x[0] = (x1[0] / 10000 * 10000) + (x1[1] % 10000);
            x[1] = (x1[1] / 10000 * 10000) + (x1[0] % 10000);
            x[2] = (x1[2] / 10000 * 10000) + (x1[3] % 10000);
            x[3] = (x1[3] / 10000 * 10000) + (x1[2] % 10000);
            for (int i = 0; i < x.Length; i++)
            {
                xstr[i] = Convert.ToString(x[i]);
                while (xstr[i].Length < 6) xstr[i] = xstr[i].Insert(0, "0");
            }
            return xstr;
        }
        
    }
}
