using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical3_prog3
{
    public class RBI
    {
        public void calculateInterest(double intrest,double time,double Rate) {
            Console.WriteLine("This is Calc From Rbi::{0}/$",((intrest*time*Rate)/100));
        }
    }
    public class Hdfc:RBI {
        public void calculateInterest(double intrest, double time, double Rate)
        {
            Console.WriteLine("This is Calc From HDFC::{0}/$", ((intrest * time * Rate) / 100));
        }
    }
    public class Sbi : RBI {
        public void calculateInterest(double intrest, double time, double Rate)
        {
            Console.WriteLine("This is Calc From Sbi::{0}/$", ((intrest * time * Rate) / 100));
        }
    }
    public class Icici : RBI {
        public void calculateInterest(double intrest, double time, double Rate)
        {
            Console.WriteLine("This is Calc From icici::{0}/$", ((intrest * time * Rate) / 100));
        }

    }
}
