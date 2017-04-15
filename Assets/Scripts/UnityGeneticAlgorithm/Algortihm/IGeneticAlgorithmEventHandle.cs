using System;
using UnityGeneticAlgorithm.Solution;

namespace UnityGeneticAlgorithm.Algorithm {
	public interface IGeneticAlgorithmEventHandle {
		void onGenerationUpdated(int generation);
		void onEvaluationUpdated(int evaluation);

		void onInitializate(string iterationType, int maxIterations);
		void onBestSolutionUpdated(Object best);

		void onIteration(int iteration);
	}
}
