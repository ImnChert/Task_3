using System;

namespace Warehouse.Interfaces
{
	public class StorageMethod
	{
		public int Temperature { get; set; }

		public StorageMethod(int temperature)
		{
			Temperature = temperature;
		}

		public override bool Equals(object obj)
		{
			return obj is StorageMethod method &&
				   Temperature == method.Temperature;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Temperature);
		}
	}
}
