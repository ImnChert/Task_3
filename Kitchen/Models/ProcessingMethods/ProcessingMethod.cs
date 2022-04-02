using System.Threading;
using Warehouse.Models;

namespace Kitchen.Models.ProcessingMethods
{
	public abstract class ProcessingMethod
	{
		protected static Semaphore s_sem;
		/// <summary>
		/// Start processing.
		/// </summary>
		/// <param name="ingredient">Ingredient.</param>
		/// <param name="count">Count.</param>
		public void StartProcessing(Ingredient ingredient, int count = 1)
		{
			s_sem.WaitOne();
			Processing(ingredient, count);
			s_sem.Release();
		}
		/// <summary>
		/// Processing.
		/// </summary>
		/// <param name="ingredient">Ingredient.</param>
		/// <param name="count">Count.</param>
		private protected abstract void Processing(Ingredient ingredient, int count = 1);
	}
}
