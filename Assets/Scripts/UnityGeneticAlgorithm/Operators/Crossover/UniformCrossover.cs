using System;
using System.Collections.Generic;
using UnityGeneticAlgorithm.Solution;

namespace UnityGeneticAlgorithm.Operators.Crossover {
	public class UniformCrossover<T>: ICrossoverOperator<T> {
		private double probability;

		public UniformCrossover() {
			probability = 0.01;
		}

		public double Probability {
			get {
				return probability;
			}

			set {
				probability = value;
			}
		}

		public List<ISolution<T>> Execute(ref List<ISolution<T>> parents) {
			if (parents.Count > 2 || parents.Count < 2) {
				throw new InvalidOperationException();
			}

			var random = new Random();
			var offspring01 = parents[0].Clone();
			var offspring02 = parents[0].Clone();

			if (probability <= random.NextDouble()) {
				for (int i = 0; i < offspring01.Data.Length; i += 1) {
					if (random.NextDouble() <= 0.5) {
						offspring01.Data[i] = parents[0].Data[i];
						offspring02.Data[i] = parents[1].Data[i];
					} else {
						offspring01.Data[i] = parents[1].Data[i];
						offspring02.Data[i] = parents[0].Data[i];
					}
				}
			}

			var offsprings = new List<ISolution<T>>(2);
			offsprings.Add(offspring01);
			offsprings.Add(offspring02);

			return offsprings;
		}


	}
}
