using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prac4_prog7
{
    interface Shape{

        public void Circle(double r);
        public void Triangle(double bases,double height);

        public void Rectangle(double widths,double heights);
    }
    internal class Aress:Shape
    {

        public void Circle(double r) {
            Console.WriteLine("Area pf circle is:{0}",(3.14*r*r));
        }
        public void Triangle(double bases, double height)
        { 
            Console.WriteLine("Area of Triangle is:{0}",(.5*bases*height));
        }

        public void Rectangle(double widths, double heights) {
            Console.WriteLine("Area of rectangle is:{0}", (widths* heights));
        }
    }
}
