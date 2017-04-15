using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityGeneticAlgorithm.Operators;
using UnityGeneticAlgorithm.Solution;

namespace UnityGeneticAlgorithm.Algorithm {
	[Serializable]
	public abstract class AGeneticAlgorithm<T> : IExecutableAlgorithm {
		bool isRuning;
		List<ISolution<T>> population;
		int currentEvaluation;
		int currentGeneration;

		public int populationSize = 100;
		public int maxIterations = 2000;

		public StoppingCriteriaType stoppingCriteria = StoppingCriteriaType.EVALUATION;

		public ISolutionManager<T> sManager;
		public ISelectionOperator<T> selection;
		public ICrossoverOperator<T> crossover;
		public IMutationOperation<T> mutation;

		private IGeneticAlgorithmEventHandle eventHandle = null;

		//todo: Evalueation and Replacement should be done by operators in the future

		public AGeneticAlgorithm() {
			isRuning = false;
			currentEvaluation = 0;
			currentGeneration = 0;
		}

		public int PopulationSize {
			get {
				return populationSize;
			}
		}

		public IGeneticAlgorithmEventHandle EventHandle {
			get {
				return eventHandle;
			}

			set {
				eventHandle = value;
			}
		}

		public bool ShouldStop {
			get {
				if (stoppingCriteria == StoppingCriteriaType.EVALUATION) {
					return (currentEvaluation >= maxIterations);
				} else {
					return (currentGeneration >= maxIterations);
				}
			}
		}

		public int CurrentIteration {
			get {
				if (stoppingCriteria == StoppingCriteriaType.EVALUATION) {
					return (currentEvaluation);
				} else {
					return (currentGeneration);
				}
			}
		}

		public void StartRunning() {
            InitializePopulation();
			EvaluatePopultion(ref population);
            
			currentEvaluation = 0;
            currentGeneration = 0;

			if (eventHandle != null) {
				eventHandle.onInitializate(stoppingCriteria.ToString(), maxIterations);
			}

            isRuning = true;
        }

		public void StopRunning() {
			isRuning = false;
		}

        public void Update() {
			if(!isRuning || ShouldStop) { return; }

            var matingPopulation = ExpandPopulation(population);

            EvaluatePopultion(ref matingPopulation);
            population = ReplacePopulation(population, matingPopulation);

            currentGeneration += 1;

			if (eventHandle != null) {
				//eventHandle.onGenerationUpdated(currentGeneration);
				//eventHandle.onEvaluationUpdated(currentEvaluation);
				eventHandle.onIteration(CurrentIteration);
			}
        }

        void InitializePopulation() {
			if (population == null) {
				population = new List<ISolution<T>>(populationSize);
			} else {
				population.Clear();
			}

            for (int i = 0; i < populationSize; i += 1) {
                var sol = sManager.CreateSolution();
                sol.Generation = currentGeneration;
                population.Add(sol);      
            }
        }

        protected virtual void EvaluatePopultion (ref List<ISolution<T>> population) {
			for(int i = 0; i < population.Count; i += 1) {
                var sol = population[i];
                var fitness = sManager.Evaluate(ref sol);
                sol.Evaluation = currentEvaluation;
                sol.Fitness = fitness;
                currentEvaluation += 1;
            }
        }

        protected virtual void Mutate(ref ISolution<T> sol) {
			mutation.Execute(ref sol);
        }

        protected abstract List<ISolution<T>> ExpandPopulation(List<ISolution<T>> population);
        protected abstract List<ISolution<T>> ReplacePopulation(List<ISolution<T>> currentPopulation, 
		                                                     List<ISolution<T>> matingPopulation);
    }
}