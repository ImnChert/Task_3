using System.Threading;
using Warehouse.Models;

namespace Kitchen.Models.ProcessingMethods
{
	public class Cutting : ProcessingMethod
	{
		static Cutting()
		{
			s_sem = new Semaphore(1, 3);
		}

		private protected override void Processing(Ingredient ingredient, int count = 1)
		{

		}
	}
}
