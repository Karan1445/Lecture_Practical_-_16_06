using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac3_prog6
{
    public class Area
    {
        public void CalArea(int basee)
        {
            Console.WriteLine("Ares Of Square:{0}", (basee * basee));
        }

        public void CalArea(double Radius)
        {
            Console.WriteLine("Area of Circle:{0}", (3.14 * Radius * Radius));
        }
        public void CalArea(double wid, double hei)
        {
            Console.WriteLine("Area of Reactangle:{0}", (wid * hei));
        }
    }
}
