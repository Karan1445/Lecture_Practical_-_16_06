//String methodos

string name = "darshan";
string name1 = "uni";
int length_name = name.Length;
Console.WriteLine("Lower Case Example :: {0}", name.ToLower());
Console.WriteLine("Upper Case Example :: {0}", name1.ToUpper());
Console.WriteLine(name.Replace("darshan", "karan"));

//--------------------------

string joined_string = string.Concat(name, name1);
Console.WriteLine(joined_string);

string joined_string1 = string.Concat(name, "University");
Console.WriteLine(joined_string1);

//----------------------------

bool result_Compare = name.Equals(name1);

//-----------------------------
string string_demo1 = "This is \"Karan\" .";

Console.WriteLine(string_demo1);

//------------------------

string subString_demo = name1.Substring(2);
Console.WriteLine(subString_demo);
string subString_demo1 = name.Substring(0, 4);
Console.WriteLine(subString_demo1);

int compare_demo = String.Compare(name, name1);
Console.WriteLine(compare_demo);

Console.WriteLine(name.Insert(1, "hello"));