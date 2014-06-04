using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KatasMindcamp;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
	[TestClass]
	public class FiscalParadiseTest
	{
		[TestInitialize]
		public void Setup()
		{
		}

		[TestMethod]
		public void FiscalParadises_have_correct_data()
		{
			Assert.AreEqual(FiscalParadises.Lux.Tax, 2);
			Assert.AreEqual(FiscalParadises.Suiz.Tax, 1);
			Assert.AreEqual(FiscalParadises.Baham.Tax, 1.5m);
		}

		[TestMethod]
		public void FiscalParadises_calculate_correct_taxes()
		{
			TaxesByCountryVM luxDto = FiscalParadises.Lux.CalculateTaxes(16m);
			TaxesByCountryVM suizDto = FiscalParadises.Suiz.CalculateTaxes(11m);
			TaxesByCountryVM bahamDto= FiscalParadises.Baham.CalculateTaxes(11m);

			Assert.AreEqual(luxDto.Discount, 0.32m);
			Assert.AreEqual(suizDto.Discount, 0.11m);
			Assert.AreEqual(bahamDto.Discount, 0.165m);
		}

		[TestMethod]
		public void FiscalParadises_calculate_cant_calculate_taxes_with_low_amount()
		{
			TaxesByCountryVM luxDto = FiscalParadises.Lux.CalculateTaxes(10m);
			TaxesByCountryVM suizDto = FiscalParadises.Suiz.CalculateTaxes(10m);
			TaxesByCountryVM bahamDto = FiscalParadises.Baham.CalculateTaxes(10m);

			Assert.AreEqual(luxDto.Discount, 0);
			Assert.AreEqual(suizDto.Discount, 0);
			Assert.AreEqual(bahamDto.Discount, 0);
		}

	}
}
