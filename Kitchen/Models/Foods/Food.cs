using Kitchen.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Warehouse;

namespace Kitchen.Models.Foods
{
	public abstract class Food : IMeal
	{
		public string Title { get; }
		public CollectionIngredients Ingredients { get; }
		public int Price { get; set; }

		public Food(string title)
		{
			Title = title;
			Ingredients = SetIngredients();
			Price = Ingredients.Dictionary.Sum(x => x.Value * x.Key.Price);
		}
		/// <summary>
		/// Set ingredients.
		/// </summary>
		/// <returns>CollectionIngredients.</returns>
		protected abstract CollectionIngredients SetIngredients();
		/// <summary>
		/// Create food.
		/// </summary>
		public void Create()
		{
			var processing = Task.Factory.StartNew(() =>
			{
				Processing();
			});

			processing.Wait();
		}
		/// <summary>
		/// Processing.
		/// </summary>
		protected abstract void Processing();

		public override bool Equals(object obj)
		{
			return obj is Food food &&
				   Title == food.Title &&
				   Price == food.Price;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Title, Price);
		}
	}
}
