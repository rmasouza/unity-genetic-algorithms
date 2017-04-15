
using System;
using System.Linq;
using System.Collections.Generic;
using UnityGeneticAlgorithm.Solution;

namespace Demos.PartitionProblem {
	public class NumberSet : ISolution<int> {
		private int[] data;

		private int evaluation = 0;
		private int generation = 0;

		public double leftSum = 0;
		public double rightSum = 0;

		double absDiff = double.MaxValue;

		public NumberSet(int dataSize) {
			data = new int[dataSize]; 
		}

		public Dictionary<int, int> IndexedData {
			get {
				return data.Select((v, index) => new {index, v})
					       .ToDictionary((arg) => arg.index, (arg) => arg.v);
			}
		}

		public int[] Left {
			get {
				return IndexedData.Where(obj => obj.Value == 0)
					              .Select(obj => obj.Key)
					              .ToArray();
			}
		}

		public int[] Right {
			get {
				return IndexedData.Where(obj => obj.Value == 1)   
					              .Select(obj => obj.Key)
					              .ToArray();
				
			}
		}

		public int[] Data {
			get {
				return data;
			}

			set {
				data = value;
			}
		}

		public int Evaluation {
			get {
				return evaluation;
			}

			set {
				evaluation = value;
			}
		}

		public double Fitness {
			get {
				return absDiff;
			}

			set {
				absDiff = Math.Abs(value);
			}
		}

		public int Generation {
			get {
				return generation;
			}

			set {
				generation = value;
			}
		}

		public ISolution<int> Clone() {
			var tmp = new NumberSet(data.Length);
			tmp.data = (int[]) data.Clone();

			return tmp;
		}

		public int Compare(ref ISolution<int> sol) {
			return Fitness.CompareTo(sol.Fitness);
		}
	}
}
