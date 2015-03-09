using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KatasMindcamp;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class FiscalParadiseTest
    {
        [TestInitialize]
        public void Setup()
        {
            FiscalParadiseBase.Lux.ClearExpenses();
            FiscalParadiseBase.Baham.ClearExpenses();
            FiscalParadiseBase.Suiz.ClearExpenses();
        }

        [TestMethod]
        public void FiscalParadises_have_correct_data()
        {
            Assert.AreEqual(FiscalParadiseBase.Lux.Tax, 2);
            Assert.AreEqual(FiscalParadiseBase.Suiz.Tax, 1);
            Assert.AreEqual(FiscalParadiseBase.Baham.Tax, 1.5m);
        }

        [TestMethod]
        public void Can_add_expense_to_fiscal_paradise()
        {
            var diputado = new Diputado("Nombre", "Pais", "Partido");
            FiscalParadiseBase.Lux.AddExpense(diputado.Name, Expense.LiveInBelgium);

            Assert.AreEqual(FiscalParadiseBase.Lux.GetExpenses(diputado.Name).Single(), Expense.LiveInBelgium);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Se ha intentado añadir una dieta a un pais que ya contenia esa dieta")]
        public void Can_not_add_expense_to_fiscal_paradise_with_diputado_and_expense()
        {
            var diputado = new Diputado("Nombre", "Pais", "Partido");
            FiscalParadiseBase.Lux.AddExpense(diputado.Name, Expense.LiveInBelgium);
            FiscalParadiseBase.Lux.AddExpense(diputado.Name, Expense.LiveInBelgium);
        }
    }
}
