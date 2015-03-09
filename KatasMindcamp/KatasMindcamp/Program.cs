using System;
using System.Linq;
using KatasMindcamp.Services;

namespace KatasMindcamp
{
	class Program
	{
		static void Main(string[] args)
		{
			Diputado diputado = new Diputado("Sesareo", "Cañamares", "MindCampTeam");
			var service = new TaxesCalculatorService();
			diputado.AddExpense(Expense.President);
			diputado.AddExpense(Expense.Tips);

			Console.WriteLine("Estos son los datos del diputado: ");
			Console.WriteLine("Nombre: {0}", diputado.Name);
			Console.WriteLine("País: {0}", diputado.Country);
			Console.WriteLine("Partido: {0}", diputado.Team);
			Console.WriteLine("******************************************");
			Console.WriteLine("Dietas: \n");
			foreach (var expense in diputado.Expenses)
			{
				Console.WriteLine(expense + ", Quantity: " + (int)expense);
			}
			Console.WriteLine("_________________________________________--");

			Console.WriteLine("Total de dietas: {0} \n\r", diputado.Expenses.Sum(x => (int)x));
			diputado.AddExpenseToFiscalParadise(Expense.President,FiscalParadiseBase.Lux);
			diputado.AddExpenseToFiscalParadise(Expense.Tips, FiscalParadiseBase.Lux);

			foreach (var country in diputado.GetFiscalParadises())
			{
				var discount = service.CalculateTaxesInCountryByDiputado(diputado, country);
				Console.WriteLine("País: {0} Total Impuestos: {1}k", country.Name, discount);
			}


			Console.ReadLine();


		}
	}
}
