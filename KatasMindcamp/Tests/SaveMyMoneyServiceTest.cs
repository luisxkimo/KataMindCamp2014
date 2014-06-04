using KatasMindcamp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	[TestClass]
	public class SaveMyMoneyServiceTest
	{
		SaveBlackMoneyService service;
		Diputado diputado;

		[TestInitialize]
		public void SetUp()
		{
			service = new SaveBlackMoneyService(); 
			diputado = new Diputado("Jorgel", "Albacete", "BarbitasSinFronteras");
			diputado.AddBlackMoney(Expense.Various);
			diputado.AddBlackMoney(Expense.LiveInBelgium);

		}

		[TestMethod]
		public void Can_Add_Money_In_Fiscal_Pardise()
		{
			var canSaveMoney = service.SaveMyMoney(diputado.Name,Expense.Various, FiscalParadises.Lux);

			Assert.AreNotEqual(canSaveMoney, "Fail");

			var saveMoney = service.FindSaveMoneyByName(diputado.Name);
			Assert.AreEqual(saveMoney.Single().Keys.Count, 1);
			Assert.AreEqual(saveMoney.Single().Keys.First(),Expense.Various);
			Assert.AreEqual(saveMoney.Single().Values.First().Name, FiscalParadises.Lux.Name);
		}
	}
}
