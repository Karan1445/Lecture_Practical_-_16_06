using System.Collections;
//contains return Deafult size of 4 but increat to 8 when 4 size got full
ArrayList DemoArray1= new ArrayList();
Console.WriteLine("-----------------------Array-----------------");
DemoArray1.Add("Karan");
DemoArray1.Add("Ronak");

DemoArray1.Remove("Karan");

DemoArray1.Insert(1, "Parth");

DemoArray1.RemoveAt(0);

Console.WriteLine(DemoArray1.Count);

foreach (object i in DemoArray1) { 
    Console.WriteLine(i);
}
Console.WriteLine("-----------------------Stack-----------------");
Stack DemoStack1= new Stack();

DemoStack1.Push("Yagnik");
DemoStack1.Push("Parth");

DemoStack1.Pop();

Console.WriteLine("Peek: "+DemoStack1.Peek());
Console.WriteLine("Contains 'Yagnik': " + DemoStack1.Contains("Yagnik"));


foreach (object i in DemoStack1)
{
    Console.WriteLine(i);
}

Console.WriteLine("-----------------------Queue-----------------");

Queue DemoQueue1=new Queue();

DemoQueue1.Enqueue("Karan");
DemoQueue1.Enqueue("Ronak");
DemoQueue1.Enqueue("Parth");



Console.WriteLine("Peek:"+DemoQueue1.Peek());
Console.WriteLine();

DemoQueue1.Dequeue();

foreach (object i in DemoQueue1)
{
    Console.WriteLine(i);
}

Hashtable DemoHashtable1 = new Hashtable();

