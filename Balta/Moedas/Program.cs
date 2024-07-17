using System.Globalization;

Console.Clear();

decimal valor = 10536.25m; // no tipo decimal, é necessário a letra m no final

Console.WriteLine(valor.ToString("C",CultureInfo.CreateSpecificCulture("pt-BR"))); // a letra C é pra aplicar o tipo de moeda do país especificado através do cultureinfo.createspecificculture
Console.WriteLine(valor.ToString("F",CultureInfo.CreateSpecificCulture("pt-BR")));

Console.WriteLine(valor.ToString("P",CultureInfo.CreateSpecificCulture("pt-BR")));

Console.WriteLine(valor.ToString("N",CultureInfo.CreateSpecificCulture("pt-BR")));

Console.WriteLine(Math.Round(valor)); // arredonda o valor

Console.WriteLine(Math.Ceiling(valor)); // arredonda o valor pra cima
Console.WriteLine(Math.Floor(valor)); // arredonda o valor pra baixo