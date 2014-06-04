using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KatasMindcamp;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
	[TestClass]
	public class DiputadoTests
	{
		Diputado diputadoGenerico;
		[TestInitialize]
		public void Setup()
		{
			diputadoGenerico = new Diputado("Generico", "España", "PartidoGenerico");
		}

		[TestMethod]
		public void Can_create_correct_diputado()
		{
			var nuevoDiputado = new Diputado("Doraemon", "España", "GatosCosmicosUnidos");

			Assert.IsNotNull(nuevoDiputado.BlackMoneys,"Las blackMoneys no pueden ser null");
			Assert.AreEqual(nuevoDiputado.Name,"Doraemon");
			Assert.AreEqual(nuevoDiputado.Country, "España");
			Assert.AreEqual(nuevoDiputado.Team, "GatosCosmicosUnidos");
			Assert.AreEqual(nuevoDiputado.Salary, 40);
		}

		[TestMethod]
		public void Can_Add_BlackMoney()
		{
			diputadoGenerico.AddBlackMoney(Expense.Tips);

			Assert.AreEqual(diputadoGenerico.BlackMoneys.Count,1);
			Assert.IsTrue(diputadoGenerico.BlackMoneys.Contains(Expense.Tips));
			Assert.AreEqual((int)diputadoGenerico.BlackMoneys.Single(), (int)Expense.Tips);
		}

		[TestMethod]
		public void Can_change_base_salary()
		{
			diputadoGenerico.ChangeSalary(30);
			Assert.AreEqual(diputadoGenerico.Salary, 30);
		}

		[TestMethod]
		public void Can_get_taxes()
		{
			var taxes = diputadoGenerico.GetDiscounts();

			Assert.IsNotNull(taxes.Single(x => x.Country == FiscalParadises.Lux.Name));
			Assert.IsNotNull(taxes.Single(x => x.Country == FiscalParadises.Suiz.Name));
			Assert.IsNotNull(taxes.Single(x => x.Country == FiscalParadises.Baham.Name));
		}
	}
}
