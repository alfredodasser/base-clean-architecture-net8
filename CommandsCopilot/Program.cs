using System;

public class Calculadora
{
    public int Sumar(int a, int b) => a + b;
}

public class Program
{
    public static void Main()
    {
        var calc = new Calculadora();
        Console.WriteLine(calc.Sumar(2, 3));
    }
}