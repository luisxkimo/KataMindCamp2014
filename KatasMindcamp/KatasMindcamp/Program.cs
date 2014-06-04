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
			diputado.AddBlackMoney(Expense.LiveInBelgium);

			Console.WriteLine("Estos son los datos del diputado: ");
			Console.WriteLine("Nombre: {0}", diputado.Name);
			Console.WriteLine("País: {0}", diputado.Country);
			Console.WriteLine("Partido: {0}", diputado.Team);
			Console.WriteLine("Dietas: ");
			foreach (var bb in diputado.BlackMoneys)
			{
				Console.WriteLine(bb + ", Quantity: "+ (int)bb);
			}
			Console.ReadLine();

			
		}
	}
}
