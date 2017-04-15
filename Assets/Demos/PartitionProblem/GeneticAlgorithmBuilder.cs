using System;
using UnityEngine;
using UnityGeneticAlgorithm;
using UnityGeneticAlgorithm.Algorithm;
using UnityGeneticAlgorithm.UI;
using UnityGeneticAlgorithm.Operators.Crossover;
using UnityGeneticAlgorithm.Operators.Mutation;
using UnityGeneticAlgorithm.Operators.Selection;

namespace Demos.PartitionProblem {
	public class GeneticAlgorithmBuilder: MonoBehaviour {
		[SerializeField]
		private GeneticAlgorithmRunner algorithmRunner = null;
		[SerializeField]
		private GeneticAlgorithmEventHandle eventHandle = null;
		[SerializeField]
		private PartitionProblemManager problemManager = null;

		private AGeneticAlgorithm<int> ga = null;

		void Start() {
			algorithmRunner = GeneticAlgorithmRunner.Instance;
			eventHandle = GeneticAlgorithmEventHandle.Instance;
			problemManager = PartitionProblemManager.Instance;
			//todo: adiciina  os componentes de interface ao eventHandle
		}

		public void BuildGeneticAlgorithm() {
			var selection = new RandomSelection<int>();
			var crossover = new UniformCrossover<int>();
			var mutation = new BinaryUniformMutation();

			ga = new GenerationalGeneticAlgortihm<int>();
			ga.selection = selection;
			ga.crossover = crossover;
			ga.mutation = mutation;
			ga.sManager = problemManager;

			ga.populationSize = 10;
			ga.maxIterations = 10000;

			ga.EventHandle = eventHandle;

			algorithmRunner.Ga = ga;

			print("GeneticAlgorithmBuilder builded ga. " + gameObject.GetInstanceID());
		}
	}
}
