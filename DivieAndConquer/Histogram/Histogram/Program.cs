using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] values = new int[] { 1, 2, 5, 6, 3, 0, 8, 4 };
            int[] values = new int[] { 5, 1, 1, 5 };
            CalculateMinStrokes(values);
            values = new int[] { 0 };
            CalculateMinStrokes(values);
            values = new int[] { 0,0,0};
            CalculateMinStrokes(values);
            values = new int[] { 1};
            CalculateMinStrokes(values);
            values = new int[] { 1,2 };
            CalculateMinStrokes(values);
            values = new int[] { 1, 2, 5, 6, 3, 0, 8, 4 };
            CalculateMinStrokes(values);
        }

        private static void CalculateMinStrokes(int[] values)
        {
            var v = (int[])values.Clone();
            int max = Process(v, 0, values.Length);
            Console.WriteLine("Bars {0}", string.Join(",", values));
            Console.WriteLine("Strokes {0}", max);
        }

        private static int Process(int[] values, int start, int end)
        {
            int strokes = 0;
            int e = start;
            if (start > end) return 0;
            if (start >= values.Length) return 0;
            
            while (e < end)
            {
                //Break into chunks separated by zeros
                for (e = start; e < end; e++)
                {
                    if (values[e] == 0)
                    {
                        break;
                    }
                }

                strokes += Stroke(values, start, e);
                start = e+1;
                e = start;
            }
            return strokes;
        }

        private static int Stroke(int[] values, int s, int e)
        {
            int maxStrokeH = e - s;
            int maxStrokeV = values[s];
            int maxvi = s;
            for (int i = s; i < e; i++)
            {
                if(maxStrokeV < values[i])
                {
                    maxStrokeV = values[i];
                    maxvi = s;
                }
            }

            if(maxStrokeH == maxStrokeV  && maxStrokeV == 0)
            {
                return 0;
            }

            if (maxStrokeV > maxStrokeH)
            {
                //Vertical stroke
                values[maxvi] = 0;
                return Process(values, s + 1, e) + 1;
            }

            //horizontal stroke
            for (int i = s; i < e; i++)
            {
                values[i] -= 1;
            }
            return Process(values, s, e) + 1;
        }
    }
}
