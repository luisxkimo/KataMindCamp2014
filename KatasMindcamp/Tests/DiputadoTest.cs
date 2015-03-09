using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KatasMindcamp;
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

            Assert.IsNotNull(nuevoDiputado.Expenses, "Las blackMoneys no pueden ser null");
            Assert.AreEqual(nuevoDiputado.Name, "Doraemon");
            Assert.AreEqual(nuevoDiputado.Country, "España");
            Assert.AreEqual(nuevoDiputado.Team, "GatosCosmicosUnidos");
            Assert.AreEqual(nuevoDiputado.Salary, 40);
        }

        [TestMethod]
        public void Can_Add_Expense()
        {
            diputadoGenerico.AddExpense(Expense.Tips);

            Assert.AreEqual(diputadoGenerico.Expenses.Count, 1);
            Assert.IsTrue(diputadoGenerico.Expenses.Contains(Expense.Tips));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Se ha intentado añadir una dieta ya existente")]
        public void Add_existing_expense_throws_ArgumentException()
        {
            diputadoGenerico.AddExpense(Expense.Tips);
            diputadoGenerico.AddExpense(Expense.Tips);
        }

        [TestMethod]
        public void Can_change_base_salary()
        {
            diputadoGenerico.ChangeSalary(30);
            Assert.AreEqual(diputadoGenerico.Salary, 30);
        }

        
    }
}
