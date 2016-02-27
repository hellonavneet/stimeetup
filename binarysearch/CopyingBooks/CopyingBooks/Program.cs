using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyingBooks
{
    class Program
    {
        /*
        Input #books, #pages in each book, #copiers
        Assign continuous # of books to a worker and minimize the maximum number of pages to copy each worker.
        */
        static void Main(string[] args)
        {
            int[] pages = { 3, 1, 2, 2, 2, 3, 1, 4 };
            int copiers = 4;

            int totalPages = pages.Sum();
            int minPages = 0;
            int maxPages = totalPages;
            int assignPages = 0;
            Console.WriteLine("Calculating ...");
            do
            {
                assignPages = (minPages + maxPages) / 2;
                var result = check(pages, copiers, assignPages);
                if (result == 0)
                    break;
                if(result == -1)
                {
                    maxPages = assignPages;
                }
                else
                {
                    minPages = assignPages;
                }
            } while (true);

            Console.WriteLine("Pages {0}" ,assignPages);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pages"></param>
        /// <param name="copiers"></param>
        /// <param name="maxAssignedPages"></param>
        /// <returns>0 - if all workers will be working, -1 - some copiers are idle, 1 - if not all books can be copied.</returns>
        static int check(int []pages, int copiers, int maxAssignedPages)
        {
            //Calculate that by given maxAssignedPages can we allocate work to all workers
            int copiersNeeded = 0;
            int totalPages = 0;
            for (int i = 0; i < pages.Length; i++)
            {
                if(totalPages >= maxAssignedPages)
                {
                    copiersNeeded++;
                    totalPages = 0;
                }
                totalPages += pages[i];
            }
            copiersNeeded++;
            if (copiersNeeded == copiers)
                return 0;
            if (copiersNeeded < copiers)
                return -1;
            return 1;
        }
    }
}
