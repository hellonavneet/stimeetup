using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movingaverage
{
    class Program
    {
        static void Main(string[] args)
        {
            WitoutStream();
            WithStream();
        }

        private static void WitoutStream()
        {
            int[] arr = new int[] { 1, 2, 5, 6, 3, 0, 8, 4 };
            List<double> avgs = new List<double>();
            double sum = 0.0;
            int k = 3;

            if (k > arr.Length || k <= 0)
            {
                throw new ArgumentException("k");
            }

            for (int i = 0; i < k; i++)
            {
                sum += arr[i];
            }


            avgs.Add(sum / k);
            for (int i = k; i < arr.Length; i++)
            {
                sum -= arr[i - k];
                sum += arr[i];
                avgs.Add(sum / k);
            }

            Console.WriteLine("Averages {0}", string.Join(",", avgs));
        }

        //Can not look back (additional k space complexity)
        private static void WithStream()
        {
            int[] arr = new int[] { 1, 2, 5, 6, 3, 0, 8, 4 };
            Queue<int> q = new Queue<int>();
            List<double> avgs = new List<double>();
            double sum = 0.0;
            int k = 3;

            if (k > arr.Length || k <= 0)
            {
                throw new ArgumentException("k");
            }

            for (int i = 0; i < k; i++)
            {
                sum += arr[i];
                q.Enqueue(arr[i]);
            }


            avgs.Add(sum / k);
            for (int i = k; i < arr.Length; i++)
            {
                sum -= q.Dequeue();
                sum += arr[i];
                q.Enqueue(arr[i]);
                avgs.Add(sum / k);
            }
            q.Clear();
            Console.WriteLine("Averages {0}", string.Join(",", avgs));
        }
    }
}
