using System.Threading;
using Warehouse.Models;

namespace Kitchen.Models.ProcessingMethods
{
	internal class Frying : ProcessingMethod
	{
		static Frying()
		{
			s_sem = new Semaphore(1, 3);
		}

		private protected override void Processing(Ingredient ingredient, int count = 1)
		{

		}
	}
}
