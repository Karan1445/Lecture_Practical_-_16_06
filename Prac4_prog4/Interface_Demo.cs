using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prac4_prog4
{
    interface Calculate {

        public void Addition(int a,int b);
        public void Subtraction(int a,int b);
    }
    internal class Result : Calculate
    {
        public void Addition(int a, int b)
        {
            Console.WriteLine("Addtion of {0} and {1} is:{2}",a,b,(a+b));
        }
        public void Subtraction(int a, int b)
        {
            Console.WriteLine("Subtraction of {0} and {1} is:{2}", a, b, (a - b));
        }
    }
}
