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
            FiscalParadise.Lux.ClearExpenses();
            FiscalParadise.Baham.ClearExpenses();
            FiscalParadise.Suiz.ClearExpenses();
        }

        [TestMethod]
        public void FiscalParadises_have_correct_data()
        {
            Assert.AreEqual(FiscalParadise.Lux.Tax, 2);
            Assert.AreEqual(FiscalParadise.Suiz.Tax, 1);
            Assert.AreEqual(FiscalParadise.Baham.Tax, 1.5m);
        }

        [TestMethod]
        public void FiscalParadises_calculate_correct_taxes()
        {
            TaxesByCountryVM luxDto = FiscalParadise.Lux.CalculateTaxes(16m);
            TaxesByCountryVM suizDto = FiscalParadise.Suiz.CalculateTaxes(11m);
            TaxesByCountryVM bahamDto = FiscalParadise.Baham.CalculateTaxes(11m);

            Assert.AreEqual(luxDto.Discount, 0.32m);
            Assert.AreEqual(suizDto.Discount, 0.11m);
            Assert.AreEqual(bahamDto.Discount, 0.165m);
        }

        [TestMethod]
        public void FiscalParadises_calculate_cant_calculate_taxes_with_low_amount()
        {
            TaxesByCountryVM luxDto = FiscalParadise.Lux.CalculateTaxes(10m);
            TaxesByCountryVM suizDto = FiscalParadise.Suiz.CalculateTaxes(10m);
            TaxesByCountryVM bahamDto = FiscalParadise.Baham.CalculateTaxes(10m);

            Assert.AreEqual(luxDto.Discount, 0);
            Assert.AreEqual(suizDto.Discount, 0);
            Assert.AreEqual(bahamDto.Discount, 0);
        }

        [TestMethod]
        public void Can_add_expense_to_fiscal_paradise()
        {
            var diputado = new Diputado("Nombre", "Pais", "Partido");
            FiscalParadise.Lux.AddExpense(diputado.Name, Expense.LiveInBelgium);

            Assert.AreEqual(FiscalParadise.Lux.GetExpenses(diputado.Name).Single(), Expense.LiveInBelgium);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Se ha intentado añadir una dieta a un pais que ya contenia esa dieta")]
        public void Can_not_add_expense_to_fiscal_paradise_with_diputado_and_expense()
        {
            var diputado = new Diputado("Nombre", "Pais", "Partido");
            FiscalParadise.Lux.AddExpense(diputado.Name, Expense.LiveInBelgium);
            FiscalParadise.Lux.AddExpense(diputado.Name, Expense.LiveInBelgium);
        }
    }
}
