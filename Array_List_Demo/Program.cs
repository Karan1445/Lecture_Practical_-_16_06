using System.Collections;
using System.ComponentModel;

ArrayList StudentName = new ArrayList();

Console.WriteLine("Enter Yes if Your Want to repeat!:");
string Check_4_loop = Console.ReadLine();

while (Check_4_loop.ToLower()=="yes") {


    Console.WriteLine("Enter Add Remove Remove-range Clear Disply");

    switch (Convert.ToInt32(Console.ReadLine())) {
        

        case 1:
            Console.WriteLine();
            Console.WriteLine("--Add--");
            Console.WriteLine("Enter A number of data You Want to insert:");
            int Data_length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter {0} Data", Data_length);
            for (int i = 0; i < Data_length; i++) {
                Console.Write("Entered at Array[{0}] : ",i);
                StudentName.Add(Console.ReadLine());
            }
            break;
        case 2:
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("--Remove--");
            Console.WriteLine("Enter A number of INDEX You Want to REMOVE:");
            int Data_index_4_remove = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (Data_index_4_remove != 0 && Data_index_4_remove <= StudentName.Count)
                {
                    StudentName.Remove(Data_index_4_remove);
                }
                else {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter Valid Range::");
            }
            
            break;
        case 3:
            Console.WriteLine();
            Console.WriteLine("--Remove Range--");
            try
            {

                Console.WriteLine("Enter A Start number of INDEX You Want to REMOVE:");
                int Remove_start_index = Convert.ToInt32(Console.ReadLine());
                if (Remove_start_index > StudentName.Count) {
                    throw new Exception();
                }

                Console.WriteLine("Enter A Last number of INDEX You Want to REMOVE:");
                int Remove_Last_index = Convert.ToInt32(Console.ReadLine());
                if (Remove_Last_index > StudentName.Count) {
                    throw new Exception();
                }
                StudentName.RemoveRange(Remove_start_index,Remove_Last_index);
            }
            catch (Exception ex) {
                Console.WriteLine("--Enter Valid range--");
                Console.WriteLine("Enter Add Remove Remove-range Clear Disply");

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
            foreach (object i in StudentName) {
                Console.WriteLine(i);
            }
            break;
    }
}