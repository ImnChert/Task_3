using System.Collections;
using System.Collections.Generic;
using Warehouse.Interfaces;
using Warehouse.Models;
using System.Linq;
using System;

namespace Warehouse
{
	public class CollectionIngredients : IEnumerable
	{
		public Dictionary<Ingredient, int> Dictionary { get; set; }

		public CollectionIngredients()
		{
			Dictionary = new Dictionary<Ingredient, int>();
		}

		public CollectionIngredients(Dictionary<Ingredient, int> dictionary)
		{
			Dictionary = dictionary;
		}
		/// <summary>
		/// Add ingredient in the dictionary.
		/// </summary>
		/// <param name="ingredient"><Ingredient./param>
		/// <param name="count">Count.</param>
		public void Add(Ingredient ingredient, int count) => Dictionary.Add(ingredient, count);
		/// <summary>
		/// Find count of the ingredient.
		/// </summary>
		/// <param name="ingredient">Ingredient.</param>
		/// <returns>Count</returns>
		public int FindCountOfIngredient(Ingredient ingredient) => Dictionary[ingredient];

		public IEnumerator GetEnumerator()
			=> Dictionary.GetEnumerator();
		/// <summary>
		/// Finding ingredients by storage condition.
		/// </summary>
		/// <param name="storageMethod">Storage method.</param>
		/// <returns>List of ingredients.</returns>
		public List<Ingredient> FindingIngredientsByStorageCondition(StorageMethod storageMethod)
			=> (from item in Dictionary
				where item.Key.StorMethod.Temperature == storageMethod.Temperature
				select item.Key).ToList();

		public override int GetHashCode()
		{
			return HashCode.Combine(Dictionary);
		}
		/// <summary>
		/// Subtraction of collections.
		/// </summary>
		/// <param name="collection1">First collection.</param>
		/// <param name="collection2">Second collection.</param>
		/// <returns>New collection.</returns>
		/// <exception cref="Exception">Сannot be subtracted.</exception>
		public static CollectionIngredients operator -(CollectionIngredients collection1, CollectionIngredients collection2)
		{
			foreach (var item in collection2.Dictionary)
			{
				if (collection1.Dictionary[item.Key] > 0)
				{
					collection1.Dictionary[item.Key] -= collection2.Dictionary[item.Key];
				}
				else
					throw new Exception();
			}

			return collection1;
		}


	}
}
