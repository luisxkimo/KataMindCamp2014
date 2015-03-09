using System.Linq;
using KatasMindcamp;
using KatasMindcamp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class TaxServiceTest
	{
		private TaxesCalculatorService service;
		[TestInitialize]
		public void SetUp()
		{
			service = new TaxesCalculatorService();
		}

		[TestMethod]
		public void FiscalParadises_calculate_correct_taxes()
		{
			var luxDto = service.CalculateTaxes(FiscalParadiseBase.Lux, 16m);
			var suizDto = service.CalculateTaxes(FiscalParadiseBase.Suiz, 11m);
			var bahamDto = service.CalculateTaxes(FiscalParadiseBase.Baham, 11m);

			Assert.AreEqual(luxDto, 0.32m);
			Assert.AreEqual(suizDto, 0.11m);
			Assert.AreEqual(bahamDto, 0.165m);
		}

		[TestMethod]
		public void FiscalParadises_calculate_cant_calculate_taxes_with_low_amount()
		{
			var luxDto = service.CalculateTaxes(FiscalParadiseBase.Lux, 10m);
			var suizDto = service.CalculateTaxes(FiscalParadiseBase.Suiz, 10m);
			var bahamDto = service.CalculateTaxes(FiscalParadiseBase.Baham, 10m);

			Assert.AreEqual(luxDto, 0m);
			Assert.AreEqual(suizDto, 0m);
			Assert.AreEqual(bahamDto, 0m);
		}

		[TestMethod]
		public void Can_calculate_taxes()
		{
			var diputado = new Diputado("Aznar", "España", "Podemos");
			//Live in Belgium = 5K
			//TeamBoss = 12K

			diputado.AddExpense(Expense.LiveInBelgium);
			diputado.AddExpense(Expense.TeamBoss);

			var taxInLux = service.CalculateTaxesInCountryByDiputado(diputado, FiscalParadiseBase.Lux);
			var taxInBaham = service.CalculateTaxesInCountryByDiputado(diputado, FiscalParadiseBase.Baham);

			Assert.AreEqual(taxInLux, 0.34m);
			Assert.AreEqual(taxInBaham, 0m);

		}


	}
}
