using System.Text;

var texto = "esse texto é um teste";

// retorna true ou false se a string contém ou não o valor em questão
System.Console.WriteLine(texto.Contains("teste"));
System.Console.WriteLine(texto.Contains("Teste"));
System.Console.WriteLine(texto.Contains("Teste", StringComparison.OrdinalIgnoreCase)); // para ignorar o case sensitive
System.Console.WriteLine("----------------------------------------------");

// retorna true ou false se a string começa ou não com esse valor exato
Console.WriteLine(texto.StartsWith("Esse"));
Console.WriteLine(texto.StartsWith("esse"));
Console.WriteLine(texto.StartsWith(" esse"));
// retorna true ou false se a string termina ou não com esse valor exato
Console.WriteLine(texto.EndsWith("teste"));
Console.WriteLine(texto.EndsWith("Teste"));
Console.WriteLine(texto.EndsWith("teste."));
System.Console.WriteLine("----------------------------------------------");

// equals é válido para qualquer objeto
Console.WriteLine(texto.Equals("esse texto é um teste"));
Console.WriteLine(texto.Equals("Esse texto é um teste"));
Console.WriteLine(texto.Equals("Esse texto é um teste", StringComparison.OrdinalIgnoreCase));
System.Console.WriteLine("----------------------------------------------");
Console.WriteLine(texto.IndexOf("é")); //busca a posição de um item em uma lista de itens. TEM QUE SER DO MESMO TIPO
Console.WriteLine(texto.LastIndexOf("t")); //busca a última posição de um item em uma lista de itens. TEM QUE SER DO MESMO TIPO
System.Console.WriteLine("----------------------------------------------");

Console.WriteLine(texto.ToUpper()); // converte o texto de uma string para caracteres maísculos.
Console.WriteLine(texto.ToLower()); // converte o texto de uma string para caracteres minúsculos.
Console.WriteLine(texto.Insert(10, " AQUI")); // insere o valor AQUI na posição 6.
Console.WriteLine(texto.Remove(0, 5)); // remove 5 caracteres a partir da posição 0.
Console.WriteLine(texto.Length); // informa a quantidade de caracteres de uma variável.
System.Console.WriteLine("----------------------------------------------");

Console.WriteLine(texto.Replace("esse", "este")); // troca o primeiro valor pelo segundo valor.
Console.WriteLine(texto.Replace("e", "X")); // também troca cada caracter para um novo valor. NÃO SOMENTE UMA PALAVRA.
System.Console.WriteLine("----------------------------------------------");

// separa as palavras pelo separador informado, no caso, foi o caracter ESPAÇO.
var divisao = texto.Split(" ");
Console.WriteLine(divisao[0]);
Console.WriteLine(divisao[1]);
Console.WriteLine(divisao[2]);
Console.WriteLine(divisao[3]);
Console.WriteLine(divisao[4]);
System.Console.WriteLine("----------------------------------------------");

// informa a posição onde iniciar e quantas posições a partir da posição de início.
var resultado = texto.Substring(5,5);
Console.WriteLine(resultado);
System.Console.WriteLine("----------------------------------------------");

// remove os espaços do início e do final. NÃO REMOVE ESPAÇOS NO MEIO
var textinho = " este texto é um teste ";
Console.WriteLine(textinho.Trim());
System.Console.WriteLine("----------------------------------------------");

// stringBuilder é um tipo e serve para adicionar muitos caracteres a uma string, sem problemas de memória
var text = new StringBuilder();
text.Append("este ");
text.Append("texto ");
text.Append("é ");
text.Append("um ");
text.Append("teste ");
Console.WriteLine(text);