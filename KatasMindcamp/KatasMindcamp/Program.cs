using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatasMindcamp
{
    class Program
    {
        static void Main(string[] args)
        {
            Diputado diputado = new Diputado("Sesareo", "Cañamares", "MindCampTeam");
            diputado.AddExpense(Expense.President);
            diputado.AddExpense(Expense.Tips);

            Console.WriteLine("Estos son los datos del diputado: ");
            Console.WriteLine("Nombre: {0}", diputado.Name);
            Console.WriteLine("País: {0}", diputado.Country);
            Console.WriteLine("Partido: {0}", diputado.Team);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Dietas: \n");
            foreach (var expense in diputado.Expenses)
            {
                Console.WriteLine(expense + ", Quantity: " + (int) expense);
            }
            Console.WriteLine("---------------------------------------------");
            foreach (var discount in diputado.GetDiscounts())
            {
                Console.WriteLine("País: {0} con descuento {1}", discount.Country, discount.Discount);
            }
            Console.ReadLine();


        }
    }
}
