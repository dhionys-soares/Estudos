using System;

Menu();

static void Menu(){
    Console.Clear();

    Console.WriteLine("Digite o que deseja fazer:");
    Console.WriteLine("1 - Soma\n2 - Subtração\n3 - Multiplicação\n4 - Divisão\n5 - Sair");
    short res = short.Parse(Console.ReadLine());

    switch (res)
{
    case 1: Soma(); break;
    case 2: Subtracao(); break;
    case 3: Multiplicacao(); break;
    case 4: Divisao(); break;
    case 5: System.Environment.Exit(0); break;

    default: Menu(); break;
}
}
static void Soma(){
Console.Clear();

Console.WriteLine("Digite o primeiro valor:");
float v1 = float.Parse(Console.ReadLine());

Console.WriteLine("Digite o segundo valor:");
float v2 = float.Parse(Console.ReadLine());

float resultado = v1 + v2;
Console.WriteLine($"O resultado é {resultado}");
Console.ReadKey();
Menu();
}
static void Subtracao(){

Console.Clear();

Console.WriteLine("Digite o primeiro valor:");
float v1 = float.Parse(Console.ReadLine());

Console.WriteLine("Digite o segundo valor:");
float v2 = float.Parse(Console.ReadLine());

float resultado = v1 - v2;
Console.WriteLine($"O resultado é {resultado}");
Console.ReadKey();
Menu();
}
static void Divisao(){

    Console.Clear();

Console.WriteLine("Digite o primeiro valor:");
float v1 = float.Parse(Console.ReadLine());

Console.WriteLine("Digite o segundo valor:");
float v2 = float.Parse(Console.ReadLine());

float resultado = v1 / v2;
Console.WriteLine($"O resultado é {resultado}");
Console.ReadKey();
Menu();
}
static void Multiplicacao(){
    Console.Clear();

Console.WriteLine("Digite o primeiro valor:");
float v1 = float.Parse(Console.ReadLine());

Console.WriteLine("Digite o segundo valor:");
float v2 = float.Parse(Console.ReadLine());

float resultado = v1 * v2;
Console.WriteLine($"O resultado é {resultado}");
Console.ReadKey();
Menu();
}
