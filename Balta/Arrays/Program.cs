Console.Clear();

var meuArray = new int[5]{1,2,3,4,5}; // array com 5 posições de 0 a 4 inicializado de 1 a 5.
meuArray[0] = 12; // atribuindo o valor 12 a posição 0.

Console.WriteLine(meuArray[0]);
Console.WriteLine(meuArray[1]);
Console.WriteLine(meuArray[2]);
Console.WriteLine(meuArray[3]);
Console.WriteLine(meuArray[4]);

Console.WriteLine("=============================================");

var meuArray2 = new int[5]{1,2,3,4,5};
for (var item = 0; item < meuArray2.Length; item++)
{
    Console.WriteLine(meuArray2[item]);
}

Console.WriteLine("=============================================");

var meuArray3 = new int[5]{6,7,8,9,10};

foreach (var item in meuArray3)
{
    Console.WriteLine(item);
}
Console.WriteLine("=============================================");

var funcionarios = new Funcionario[5];

foreach (var funcionario in funcionarios)
{
    Console.WriteLine(funcionario.id);
}



public struct Funcionario{
    public int id {get; set;}
}