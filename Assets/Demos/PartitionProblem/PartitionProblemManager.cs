using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGeneticAlgorithm.Solution;

namespace Demos.PartitionProblem {
	public class PartitionProblemManager : MonoBehaviour, ISolutionManager<int> {
		public double[] values;
		static PartitionProblemManager _instance;

		public static PartitionProblemManager Instance {
			get {
				if (_instance == null) {
					_instance = FindObjectOfType<PartitionProblemManager>();
				}

				return _instance;
			}
		}

		public ISolution<int> CreateSolution() {
			var sol = new NumberSet(values.Length);
			var random = new System.Random();
			var data = new int[values.Length];

			for (int i = 0; i < values.Length; i += 1) {
				if (random.NextDouble() <= 0.5) {
					data[i] = 0;		
				} else { 
					data[i] = 1;
				}
			}

			sol.Data = data;
			return sol;
		}

		public double Evaluate(ref ISolution<int> solution) {
			print("Start evaluation");
			var numberSet = (NumberSet)solution;
			var leftSum = 0.0;
			var rightSum = 0.0;

			for (int i = 0; i < numberSet.Left.Length; i += 1) {
				leftSum += values[numberSet.Left[i]];
			}

			for (int i = 0; i < numberSet.Right.Length; i += 1) {
				rightSum += values[numberSet.Right[i]];
			}

			numberSet.leftSum = leftSum;
			numberSet.rightSum = rightSum;

			print("Finish evaluation");
			return leftSum - rightSum;
		}

		void Start() {
			var a = CreateSolution();
			var b = CreateSolution();

			a.Fitness = Evaluate(ref a);
			b.Fitness = Evaluate(ref b);


			print("------ a ------");
			//print("left sum: " + ((NumberSet)a).leftSum);
			//print("right sum: " + ((NumberSet)a).rightSum);
			print("fitnrss: " + ((NumberSet)a).Fitness);

			print("------ b ------");
			//print("left sum: " + ((NumberSet)b).leftSum);
			//print("right sum: " +((NumberSet)b).rightSum);
			print("fitnrss: " + ((NumberSet)b).Fitness);

			print("------ a comparisson to b ------");
			print(a.Compare(ref b));

			var array = new ISolution<int>[]{ a, b }.ToList();
			array.Sort((x, y) => x.Compare(ref y));
			array.ForEach(s => print(s.Fitness));
		}
	}
}
