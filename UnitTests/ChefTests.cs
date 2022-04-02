using Hall.Models;
using Hall.Models.Staff;
using Kitchen.Interfaces;
using Kitchen.Models.Drinks;
using Kitchen.Models.Foods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Warehouse;
using Warehouse.Models;

namespace UnitTests
{
	[TestClass]
	public class ChefTests
	{
		[TestMethod]
		public void ProcessTheOrder_CreatingAPossitiveTestSituatin_CorrectExecution()
		{
			var chef = new Chef(null, DefoultIngredietns());
			var order = new Order<IMeal>(new List<IMeal>() { new FriedEgg(), new Beer() }, 2);
			chef.ProcessTheOrder(order);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void ProcessTheOrder_NoIngredients_Exception()
		{
			var chef = new Chef(null, DefoultIngredietns());
			var order = new Order<IMeal>(new List<IMeal>() { new FriedEgg(), new FriedEgg(), new Beer() }, 2);
			chef.ProcessTheOrder(order);
		}

		private CollectionIngredients DefoultIngredietns()
		{
			var ingredients = new CollectionIngredients();
			ingredients.Add(new Egg(), 1);

			return ingredients;
		}
	}
}
