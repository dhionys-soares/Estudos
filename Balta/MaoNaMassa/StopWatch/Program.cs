﻿Menu();

static void PreStart(int time){
Console.Clear();
Console.WriteLine("Ready...");
Thread.Sleep(1000);
Console.Clear();
Console.WriteLine("Set...");
Thread.Sleep(1000);
Console.Clear();
Console.WriteLine("Go...");
Thread.Sleep(2500);

Start(time);
}

static void Start(int time)
{

    int currentTime = 0;

    while (currentTime != time)
    {
        Console.Clear();
        currentTime++;
        Console.WriteLine(currentTime);
        Thread.Sleep(1000);        
    }

    Console.Clear();
    Console.WriteLine("StopWatch finalizado");
    Thread.Sleep(2500);
    Menu();
}


static void Menu()
{
    Console.Clear();
    Console.WriteLine("Quanto tempo deseja contar?");
    Console.WriteLine("Digite uma opção:\n\nS - Segundo => 10s = 10 segundos\nM - Minuto => 1m = 1 minuto\n0 - Sair");

    string data = Console.ReadLine().ToLower();
    char type = char.Parse(data.Substring(data.Length - 1, 1));
    int time = int.Parse(data.Substring(0, data.Length - 1));

    int multiplier = 1;

    if (type == 'm')
    {
        multiplier = 60;
    }
    if (time == 0)
    {
        System.Environment.Exit(0);
    }

    PreStart(time * multiplier);
}