using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using KatasMindcamp.libs;

namespace KatasMindcamp
{
    public class Diputado
    {
        private string name;
        private int salary;
        private string country;
        private string team;
        private HashSet<Expense> _expenses;


        public Diputado(string name, string country, string team)
        {
            Check.Require(name != String.Empty);
            Check.Require(country != String.Empty);
            Check.Require(team != String.Empty);

            this.name = name;
            salary = 40;
            this.team = team;
            this.country = country;
            _expenses = new HashSet<Expense>();
            fiscalParadises = new List<FiscalParadiseBase>();

        }

        public string Name { get { return name; } }
        public int Salary { get { return salary; } }
        public string Country { get { return country; } }
        public string Team { get { return team; } }
        public HashSet<Expense> Expenses { get { return _expenses; } }
        public IList<FiscalParadiseBase> fiscalParadises;

        public void ChangeSalary(int salary)
        {
            Check.Require(salary != null);
            this.salary = salary;
        }

        public void AddExpense(Expense expense)
        {
            Check.Require(expense != null);
            if (_expenses.Contains(expense))
                throw new ArgumentException("La dieta que intenta dar de alta ya la tiene adjudicada.");
            _expenses.Add(expense);
        }


        public IEnumerable<FiscalParadiseBase> GetFiscalParadises()
        {
            return fiscalParadises;
        }

        public void AddExpenseToFiscalParadise(Expense expense, FiscalParadiseBase fiscalParadiseBase)
        {
            Check.Require(_expenses.Contains(expense));

			fiscalParadiseBase.AddExpense(name, expense);

        }
    }
}
