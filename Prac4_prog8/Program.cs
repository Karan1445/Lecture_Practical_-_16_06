Console.WriteLine("-------program-8--------");
//":::::::::::::::Enter Is odd Please Enter Even number:::::::::::"

try
{
    while (true) {
        Console.Write("Enter a number: ");
        int inp=Convert.ToInt32(Console.ReadLine());

        if (inp % 2 == 1) {
            throw new Exception(":::::::::::::::Enter Is odd Please Enter Even number:::::::::::");
        }
       }

}
catch (Exception ec) {
    
    Console.WriteLine(ec.Message);
}