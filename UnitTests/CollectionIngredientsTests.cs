using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Warehouse;
using Warehouse.Interfaces;
using Warehouse.Models;

namespace UnitTests
{
	[TestClass]
	public class CollectionIngredientsTests
	{
		[TestMethod]
		public void FindCountOfIngredients_CreatingAPossitiveTestSituatin_CorrectExecution()
		{
			var collection = new CollectionIngredients(new Dictionary<Ingredient, int>() { { new Egg(), 2 } });

			Assert.AreEqual(collection.FindCountOfIngredient(new Egg()), 2);
		}

		[TestMethod]
		public void FindingIngredientsByStorageCondition_CreatingAPossitiveTestSituatin_CorrectExecution()
		{
			var collection = new CollectionIngredients(new Dictionary<Ingredient, int>() { { new Egg(), 2 } });
			Assert.AreEqual(collection.FindingIngredientsByStorageCondition(new StorageMethod(10))[0], new Egg());
		}
	}
}
