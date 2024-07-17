using MeuExercicio.Entities;

var rpps = new Rpps("Candelária", "123456789000145", "Seu Ramon");

var carteira1 = new Carteira("Renda fixa", rpps, new List<FundoInvestimento>());
var carteira2 = new Carteira("Renda fixa2", rpps, new List<FundoInvestimento>());

var fundoInvestimento1 = new FundoInvestimento("BBSeguridade");
var fundoInvestimento2 = new FundoInvestimento("BBSeguridade2");

carteira1.FundosInvestimentos.Add(fundoInvestimento1);
carteira1.FundosInvestimentos.Add(fundoInvestimento2);

rpps.Carteiras.Add(carteira1);
rpps.Carteiras.Add(carteira2);

System.Console.WriteLine(rpps.Carteiras.Select(x => x.Nome));

