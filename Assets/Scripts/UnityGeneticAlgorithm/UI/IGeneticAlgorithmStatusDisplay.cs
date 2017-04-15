using System;
namespace UnityGeneticAlgorithm.UI {
	public interface IGeneticAlgorithmStatusDisplay {
		void UpdateIteration(int iteration);

		void SetIterationType(string type);
		void SetMaxIteration(int max);
	}
}
