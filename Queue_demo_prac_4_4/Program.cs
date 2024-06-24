using System.Collections;
using System.ComponentModel;

Queue StudentName = new Queue();

Console.WriteLine("Enter Yes if Your Want to repeat!:");
string Check_4_loop = Console.ReadLine();

while (Check_4_loop.ToLower() == "yes")
{

    Console.WriteLine();
    Console.WriteLine("Enter ENQUEUE DEQUEUE Peek Contanies Clear Disply");

    switch (Convert.ToInt32(Console.ReadLine()))
    {


        case 1:
            Console.WriteLine();
            Console.WriteLine("--ENQUEUE--");
            Console.WriteLine("Enter A number of Data Your want to ENqueue:");
            int Data_length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter {0} Data", Data_length);
            for (int i = 0; i < Data_length; i++)
            {

                StudentName.Enqueue(Console.ReadLine());
            }
            break;
        case 2:

            Console.WriteLine();
            Console.WriteLine("--DEqueue--");
            StudentName.Dequeue();

            break;
        case 3:
            Console.WriteLine();
            Console.WriteLine("--Peek--  {0}", StudentName.Peek());

            break;
        case 4:
            Console.WriteLine();
            Console.WriteLine("--Containes--");


            Console.WriteLine("Enter A Data You Want to Find:");
            var Remove_index = Console.ReadLine();

            Console.WriteLine(StudentName.Contains(Remove_index));
            break;

        case 5:
            Console.WriteLine();
            Console.WriteLine("--Cleard--");
            StudentName.Clear();
            break;

        case 6:
            Console.WriteLine();
            Console.WriteLine("--Display--");
            if (StudentName.Count != 0)
            {
                foreach (object i in StudentName)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine("==============Nothing to display==================");
            }

            break;
    }
}