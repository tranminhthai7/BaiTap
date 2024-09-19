using System;

class Program
{
    static void Main()
    {
        int a, b, n;
        Console.WriteLine("Nhập a và b:");
        a = Convert.ToInt32(Console.ReadLine());
        b = Convert.ToInt32(Console.ReadLine());
        
        n = a;
        a = b;
        b = n;
        
        Console.WriteLine(a);
        Console.WriteLine(b);
    }
}
