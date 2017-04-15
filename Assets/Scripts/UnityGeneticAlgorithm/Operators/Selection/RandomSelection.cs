using System;
using System.Collections.Generic;
using UnityGeneticAlgorithm.Solution;

namespace UnityGeneticAlgorithm.Operators.Selection{
	public class RandomSelection<T>: ISelectionOperator<T>{
		public RandomSelection(){}

		public ISolution<T> Execute(List<ISolution<T>> population) {
			var random = new Random();
			var index = random.Next(0, population.Count-1);
			return population[index];
		}
	}
}
