using System;

Menu();


static void Menu()
{
    Console.Clear();
    Console.WriteLine("O que você deseja fazer?");
    Console.WriteLine("1 - Abrir arquivo\n2 - Criar novo arquivo\n0 - Sair");
    short option = short.Parse(Console.ReadLine());

    switch (option)
    {
        case 0: System.Environment.Exit(0); break;
        case 1: Abrir(); break;
        case 2: Editar(); break;
        default: Menu(); break;
    }
}

static void Abrir()
{
Console.Clear();
Console.WriteLine("Qual o caminho do arquivo?");
string path = Console.ReadLine();

using (var file = new StreamReader(path))
{
    string text = file.ReadToEnd();
    Console.WriteLine(text);
}
Console.WriteLine("");
Console.ReadLine();
Menu();

}
static void Editar()

{
    Console.Clear();
    Console.WriteLine("Digite seu texto abaixo:(OU pressione ESC para sair)\n-------------------------------------------");
    string text = "";

do
{
    text += Console.ReadLine();
    text += Environment.NewLine;
}
while (Console.ReadKey().Key != ConsoleKey.Escape);

Salvar(text);

}
static void Salvar(string text){
    Console.Clear();
    Console.WriteLine("Digite o caminho onde você quer salvar o arquivo:");
    var path = Console.ReadLine();

    using (var file = new StreamWriter(path)) //cria um arquivo file no caminho path
    {
        file.Write(text); //escreve no arquivo file o que está salvo na variável text
    }
    Console.WriteLine("Arquivo salvo com sucesso!");
}