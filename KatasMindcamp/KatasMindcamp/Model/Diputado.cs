using DesignByContract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KatasMindcamp
{
	public class Diputado
	{
		private string name;
		private int salary;
		private string country;
		private string team;
		private List<Expense> blackMoneys;
		

		public Diputado(string name, string country, string team)
		{
			Check.Require(name != String.Empty);
			Check.Require(country != String.Empty);
			Check.Require(team != String.Empty);

			this.name = name;
			this.salary = 40;
			this.team = team;
			this.country = country;
			this.blackMoneys = new List<Expense>();

		}

		public string Name { get { return name; } }
		public int Salary { get { return salary; } }
		public string Country { get { return country; } }
		public string Team { get { return team; } }
		public List<Expense> BlackMoneys { get { return blackMoneys; } }

		public void ChangeSalary(int salary)
		{
			Check.Require(salary != null);
			this.salary = salary;
		}

		public void AddBlackMoney(Expense expense)
		{
			Check.Require(expense != null);

			blackMoneys.Add(expense);
		}

		public List<TaxesByCountryVM> GetDiscounts()
		{
			var sumDietas = blackMoneys.Sum(x => (int)x);
			List<TaxesByCountryVM> taxes = new List<TaxesByCountryVM>();

			var luxDiscount = FiscalParadises.Lux.CalculateTaxes(sumDietas);
			var bahamasDiscount = FiscalParadises.Baham.CalculateTaxes(sumDietas);
			var suizaDiscount = FiscalParadises.Suiz.CalculateTaxes(sumDietas);

			taxes.Add(luxDiscount);
			taxes.Add(bahamasDiscount);
			taxes.Add(suizaDiscount);

			return taxes;
		}
	}
}
