using Hall.Models;
using Kitchen.Interfaces;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hall.Services
{
	public class JSON
	{
		private string _filename;

		public JSON()
		{
			_filename = "test.json";
		}
		public JSON(string filename)
		{
			_filename = filename;
		}
		/// <summary>
		/// Reader.
		/// </summary>
		/// <returns>OrderList.</returns>
		public async Task<OrderList> ReaderAsync()
		{
			var collection = new OrderList();

			using (FileStream fs = new FileStream(_filename, FileMode.OpenOrCreate))
			{
				Order<IMeal>? order = await JsonSerializer.DeserializeAsync<Order<IMeal>>(fs);
				collection.Add(order);
			}

			return collection;
		}
		/// <summary>
		/// Writer
		/// </summary>
		/// <param name="collection">Order list.</param>
		/// <returns>Void.</returns>
		public async Task WriterAsync(OrderList collection)
		{
			using (FileStream fs = new FileStream(_filename, FileMode.OpenOrCreate))
			{
				foreach (Order<IMeal> order in collection.ListOfOrders)
				{
					await JsonSerializer.SerializeAsync(fs, order);
				}
			}
		}
	}
}
