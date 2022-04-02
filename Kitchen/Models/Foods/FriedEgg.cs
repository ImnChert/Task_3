using Kitchen.Models.ProcessingMethods;
using Warehouse;
using Warehouse.Models;

namespace Kitchen.Models.Foods
{
	public class FriedEgg : Food
	{
		public FriedEgg()
			: base("Fried Egg")
		{ }

		protected override void Processing()
		{
			foreach (var i in Ingredients.Dictionary)
			{
				var split = new Split();
				split.StartProcessing(i.Key, i.Value);
				var frying = new Frying();
				frying.StartProcessing(i.Key, i.Value);
			}
		}

		protected override CollectionIngredients SetIngredients()
		{
			var collection = new CollectionIngredients
			{
				{ new Egg(), 1 }
			};

			return collection;
		}
	}
}
