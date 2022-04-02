using Hall.Models;
using Hall.Services;
using Kitchen.Interfaces;
using Kitchen.Models.Drinks;
using Kitchen.Models.Foods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests
{
	[TestClass]
	public class JSONTests
	{
		[TestMethod]
		public void Reader_CorrectReader_Success()
		{
			var json = new JSON();
			OrderList collection = DeffaultCollection();

			json.WriterAsync(collection);
		}

		private OrderList DeffaultCollection()
		{
			var orderList = new OrderList();
			orderList.Add(new Order<IMeal>(new List<IMeal>() { new FriedEgg(), new Beer() }, 2));
			orderList.Add(new Order<IMeal>(new List<IMeal>() { new FriedEgg() }, 1));
			orderList.Add(new Order<IMeal>(new List<IMeal>() { new Beer() }, 4));

			return orderList;
		}
	}
}
