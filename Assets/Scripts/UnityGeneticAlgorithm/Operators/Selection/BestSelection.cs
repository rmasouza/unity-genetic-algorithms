using System;
using System.Collections.Generic;
using UnityGeneticAlgorithm.Solution;

namespace UnityGeneticAlgorithm.Operators.Selection
{
	public class BestSelection<T> : ISelectionOperator<T> {
		
		public BestSelection() { }

		public ISolution<T> Execute(List<ISolution<T>> population) {
			population.Sort((s1, s2) => s1.Compare(ref s2));
			return population[0];
		}
	}
}
