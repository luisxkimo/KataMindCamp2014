using System.Collections.Generic;
using System.Linq;
using System.Net;
using System;
using KatasMindcamp.libs;

namespace KatasMindcamp
{
	public class FiscalParadiseBase
	{
		private readonly string name;
		private readonly decimal tax;
		private decimal limitAmount;

		private readonly Dictionary<Expense, string> expensesForDiputado;

		public static readonly FiscalParadiseBase Lux = new Luxemburgo();
		public static readonly FiscalParadiseBase Suiz = new Suiza();
		public static readonly FiscalParadiseBase Baham = new Bahamas();

		private FiscalParadiseBase(string name, decimal tax, decimal limitAmount)
		{
			Check.Require(name != String.Empty);

			this.name = name;
			this.tax = tax;
			this.limitAmount = limitAmount;
			expensesForDiputado = new Dictionary<Expense, string>();
		}

		public string Name { get { return name; } }
		public decimal Tax { get { return tax; } }
		public decimal LimitAmount { get { return limitAmount; } }

		public IEnumerable<Expense> GetExpenses(string diputado)
		{
			return expensesForDiputado.Where(x => x.Value == diputado).Select(x => x.Key).ToList();
		}

		public void AddExpense(string diputado, Expense expense)
		{
			try
			{
				//todo: HAY QUE VER COMO IMPLEMENTAR el enunciado, quizas llevando esto a un servicio
				/*
				 * Una vez cobran, no saben si llevar su dinero a Suiza, Luxemburgo u otros paraísos fiscales.
				 * Un diputado no puede colocar su sueldo en paraísos fiscales pero sí las dietas. 
				 * Puede colocar distintas dietas en varios paraísos fiscales, 
				 * pero no puede colocar una misma dieta en varios.
				 * 
				 * Al diputado le gustaría tener un listado de cuánto puede "ahorrarse" 
				 * si coloca su dinero en un país u otro.
				 */
				throw new NotImplementedException();
				//expensesForDiputado.Add(expense, diputado);
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine("Este diputado ya ha almacenado la dieta especificada en este país.");
				Console.WriteLine("Desea Continuar? ");
				Console.ReadLine();
			}

		}

		public void ClearExpenses()
		{
			expensesForDiputado.Clear();
		}

		private class Luxemburgo : FiscalParadiseBase
		{
			public Luxemburgo() : base("Luxemburgo", 2m, 15) { }
		}

		private class Suiza : FiscalParadiseBase
		{
			public Suiza() : base("Suiza", 1m, 10m) { }
		}

		private class Bahamas : FiscalParadiseBase
		{
			public Bahamas() : base("Bahamas", 1.5m, 20m) { }
		}
	}


}
