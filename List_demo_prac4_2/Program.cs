using System.Collections;
using System.ComponentModel;

List<string> StudentName = new List<string>();

Console.WriteLine("Enter Yes if Your Want to repeat!:");
string Check_4_loop = Console.ReadLine();

while (Check_4_loop.ToLower() == "yes")
{

    Console.WriteLine();
    Console.WriteLine("Enter Add Remove RemoveAt Clear Disply");

    switch (Convert.ToInt32(Console.ReadLine()))
    {


        case 1:
            Console.WriteLine();
            Console.WriteLine("--Add--");
            Console.WriteLine("Enter A number of data You Want to insert:");
            int Data_length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter {0} Data", Data_length);
            for (int i = 0; i < Data_length; i++)
            {
                Console.Write("Entered at Array[{0}] : ", i);
                StudentName.Add(Console.ReadLine());
            }
            break;
        case 2:
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("--Remove--");
            Console.WriteLine("Enter A Data of INDEX You Want to REMOVE:");
            string Data_4_remove = Console.ReadLine();

                StudentName.Remove(Data_4_remove);

            break;
        case 3:
            Console.WriteLine();
            Console.WriteLine("--Remove Range--");
            try
            {

                Console.WriteLine("Enter A number of INDEX You Want to REMOVE:");
                int Remove_index = Convert.ToInt32(Console.ReadLine());
                if (Remove_index > StudentName.Count && Remove_index >0)
                {
                    throw new Exception();
                }
                StudentName.RemoveAt(Remove_index);

            }
            catch (Exception ex)
            {
                Console.WriteLine("--Enter Valid range--");
                Console.WriteLine("Enter Add Remove RemoveAt Clear Disply");

            }
            break;

        case 4:
            Console.WriteLine();
            Console.WriteLine("--Cleard--");
            StudentName.Clear();
            break;

        case 5:
            Console.WriteLine();
            Console.WriteLine("--Display--");
            if (StudentName.Count != 0)
            {
                foreach (object i in StudentName)
                {
                    Console.WriteLine(i);
                }
            }
            else {
                Console.WriteLine("==============Nothing to display==================");
            }
            
            break;
    }
}