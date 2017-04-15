using System;
using UnityGeneticAlgorithm.Operators;
using UnityGeneticAlgorithm.Solution;

namespace UnityGeneticAlgorithm.Operators.Mutation {
	public class BinaryUniformMutation: IMutationOperation<int> {
		private double probability;

		public BinaryUniformMutation() { probability = 0.01; }
		public BinaryUniformMutation(double probability) {
			this.probability = probability;
		}

		double IMutationOperation<int>.Probability {
			get {
				return probability;
			}

			set {
				probability = value;
			}
		}

		void IMutationOperation<int>.Execute(ref ISolution<int> solution) {
			for (int i = 0; i < solution.Data.Length; i += 1) {
				var random = new Random();
				if (probability <= random.NextDouble()) {
					if (solution.Data[i] == 0) {
						solution.Data[i] = 1;
					} else {
						solution.Data[i] = 0;
					}
				}
			}
		}
	}
}
