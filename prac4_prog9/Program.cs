Console.WriteLine("Enter String");
string Demo_String=Console.ReadLine();

string[] Test_array = Demo_String.Split();

int Max = Test_array[0].Length;
String Max_String="";

foreach (var i in Test_array) {
    if (Max < i.Length)
    {
        Max = i.Length;
        Max_String = i;
    }
    else { 
    Max_String=Test_array[0];
    }
    }
Console.WriteLine("Maximum length String is: {0} ans it Size is : {1}",Max_String,Max);