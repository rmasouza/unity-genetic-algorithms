using System;
using UnityEngine;
using UnityGeneticAlgorithm.Algorithm;
using UnityGeneticAlgorithm.Solution;

namespace UnityGeneticAlgorithm.UI  {
	public class GeneticAlgorithmEventHandle : MonoBehaviour, IGeneticAlgorithmEventHandle {
		[SerializeField]
		IGeneticAlgorithmStatusDisplay statusDisplay = null;
		ISolutionDisplay solutionDisplay = null;

		private static GeneticAlgorithmEventHandle _instance = null;
		public static GeneticAlgorithmEventHandle Instance {
			get {
				if (_instance == null) {
					_instance = FindObjectOfType<GeneticAlgorithmEventHandle>();
				}
				return _instance;
			}
		}

		void IGeneticAlgorithmEventHandle.onEvaluationUpdated(int evaluation) {
			print("Evaluation _ " + evaluation);
		}

		void IGeneticAlgorithmEventHandle.onGenerationUpdated(int generation) {
			print("Generation _ " + generation);
		}

		void IGeneticAlgorithmEventHandle.onInitializate(string iterationType, int maxIterations) {
			print(iterationType);
			statusDisplay.SetIterationType(iterationType);
			statusDisplay.SetMaxIteration(maxIterations);
		}

		void IGeneticAlgorithmEventHandle.onIteration(int iteration) {
			print("_ " + iteration);
			statusDisplay.UpdateIteration(iteration);
		}

		void IGeneticAlgorithmEventHandle.onBestSolutionUpdated(object best) {
			solutionDisplay.ShowSolution(best);
		}
	}
}
