Console.WriteLine("---------index_out_of_range---------");

Console.Write("Enter Size of The arry:: ");
int Size_Array=Convert.ToInt32(Console.ReadLine());

String[] Names=new String[Size_Array];

Console.Write("Enter postion you want to Enter element::");
int Current_postion=Convert.ToInt32(Console.ReadLine());
try
{
    Console.WriteLine("Enter Value At {0}:",Current_postion);
    Names[Current_postion] = Console.ReadLine();
}
catch (IndexOutOfRangeException ex) {
    Console.WriteLine(ex.Message);
}