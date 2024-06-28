Console.WriteLine("Enter A number::");
int Number=Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter a Divider::");
try {
    int Divisor=Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Output Is: {0}",(Number/Divisor));
}
catch (DivideByZeroException de) {
Console.WriteLine(de.Message);
}