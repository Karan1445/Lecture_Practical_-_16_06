using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prac3_prog5
{
    public  class Hospital
    {
        public void HospitalDetails() {
            Console.WriteLine("::::: This is Base class HOSPITAL ::::::");
        }
    }

    public class Apollo:Hospital {
        public void HospitalDetails()
        {
            Console.WriteLine("::::: This is Child class Apollo ::::::");
        }
    }
    public class Wockhardt : Hospital
    {
        public void HospitalDetails()
        {
            Console.WriteLine("::::: This is Child class Wokhard ::::::");
        }

}
    public class Gokul_Superspeciality {
        public void HospitalDetails()
        {
            Console.WriteLine("::::: This is Child class Gokul_Superspeciality ::::::");
        }
    }
}
