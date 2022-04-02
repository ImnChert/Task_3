using System.Threading;
using Warehouse.Models;

namespace Kitchen.Models.ProcessingMethods
{
	internal class Split : ProcessingMethod
	{
		static Split()
		{
			s_sem = new Semaphore(1, 2);
		}

		private protected override void Processing(Ingredient ingredient, int count = 1)
		{

		}
	}
}
