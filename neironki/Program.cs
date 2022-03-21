using System;
using System.IO;

namespace neironki
{
    class Program
    {
        public static double[] yFin = new double[2] { 0, 0 };
        public static int l = 0;
        static void Main(string[] args)
        {
            begin();            
    }

        public static void begin()
        {
            int[] x = insert();
            double[] y = new double[4];
            cycl(x);
            Console.WriteLine("Мин = " + yFin[0] + " Макс = " + yFin[1]);
        }

        public static void cycl(int[] x)
        {            
            string[] xdblStr = binar(x);
            double[] y = function(x);
            string[] crsd = cross(xdblStr);
            string[] nextGen = mutation(crsd);
            int[] nextGenDec = binToDec(nextGen);
            for (int i = 0; i < 4; i++)
            {
                if ((y[i] > yFin[1]) || double.IsNaN(yFin[1])) yFin[1] = y[i];
                if ((y[i] < yFin[0]) || double.IsNaN(yFin[0])) yFin[0] = y[i];
            }
            if (l < 50)
            {
                l++;
                cycl(nextGenDec);
            }
        }

        public static int[] insert()
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

        public static string[] binar(int[] x)
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

        public static double[] function(int[] x)
        {
            double[] y = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                x[i] -= 10;
                y[i] = 26 - (86 * x[i]) - (59 * x[i] * x[i]) + (3 * Math.Pow(x[i], 3));
            }
            
            return y;
        }

        public static string[] cross(string[] xdblStr)
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

        public static string[] mutation(string[] x)
        {
            Random rng = new Random();
            int NumPos = rng.Next() % x.Length;
            int BitePos = rng.Next() % 6;
            if (x[NumPos][BitePos] == '1')
            {
                x[NumPos] = x[NumPos].Remove(BitePos, 1);
                x[NumPos] = x[NumPos].Insert(BitePos, "0");
            }
            else
            {
                x[NumPos] = x[NumPos].Remove(BitePos, 1);
                x[NumPos] = x[NumPos].Insert(BitePos, "1");
            }

            return x;
        }

        public static int[] binToDec(string[] str)
        {
            int[] x = new int[4] { 0, 0, 0, 0 };
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    string v = Convert.ToString(str[j][i]);
                    x[j] += Convert.ToInt32(v) * Convert.ToInt32(Math.Pow(2, Math.Abs(-5 + i)));
                }
            }
            return x;
        }
        
    }
}
