using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac4_prog3
{
    public abstract class Sum
    {
        public abstract void sumOfTwo(int a, int b);

        public abstract void sumOfThree(int a, int b, int c);
    }
    internal class Calculate:Sum
    {
        public override void sum    OfTwo(int a, int b)
        {
            Console.WriteLine();
            Console.WriteLine("Sum Of Two Number Is: {0}", (a + b));
        }
        public override void sumOfThree(int a, int b, int c)
        {
            Console.WriteLine();
            Console.WriteLine("Sum Of Three Number Is: {0}", (a + b + c));
        }
    }
}
