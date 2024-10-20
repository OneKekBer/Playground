using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.SumFourDivisorsLeetCode
{
    class Program
    {
        public static void Start()
        {
            var odp = SumFourDivisors([21,4,7]);

            Console.WriteLine(odp);
        }

        public static int SumFourDivisors(int[] nums)
        {
            int summ = 0;
            foreach (var num in nums)
            {
                int counter = 0;
                int numSum = 0;

                for (int i = 1; i*i <= num; i++)
                {
                    if (num % i == 0)
                    {
                        counter ++;
                        numSum += i;

                        if (i != num / i)
                        {
                            counter++;
                            numSum += num / i;
                        }
                    }

                    if (counter > 4)
                        break;
                }

                if (counter == 4)
                    summ += numSum;
            }
            return summ;
        }
    }
}
