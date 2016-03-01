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
            //WitoutStream();
            //WithStream();
            MovingMax();
        }

        private static void MovingMax()
        {
            int[] arr = new int[] { 1, 2, 5, 6, 3, 0, 8, 4 };
            List<int> maxes = new List<int>();
            List<KeyValuePair<int,int>> q = new List<KeyValuePair<int,int>>();
            int max = int.MinValue;
            int k = 3;

            if (k > arr.Length || k <= 0)
            {
                throw new ArgumentException("k");
            }

            for (int i = 0; i < k; i++)
            {
                AddToQueue(ref q, arr[i], i, k);
            }

            maxes.Add(q[0].Key);
            for (int i = k; i < arr.Length; i++)
            {
                AddToQueue(ref q, arr[i], i, k);
                maxes.Add(q[0].Key);
            }
            Console.WriteLine("Values {0}", string.Join(",", arr));
            Console.WriteLine("Max Values {0}", string.Join(",", maxes));
        }

        private static void AddToQueue(ref List<KeyValuePair<int,int>> q, int value, int index, int k)
        {
            int insertat = q.Count;
            for (int i = q.Count-1; i >=0; i--)
            {
                //Remove all values from the queue that are less than the value
                if(q[i].Key <= value)
                {
                    insertat--;
                }
                else
                {
                    break;
                }
            }

            q.RemoveRange(insertat, q.Count-insertat);

            //Remove all the values that are at indexes which need to be slide out even if they are greater than value
            q = q.SkipWhile(kv => kv.Value <= index - k).ToList();
            q.Add(new KeyValuePair<int, int>(value, index));
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
