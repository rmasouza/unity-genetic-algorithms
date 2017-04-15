using System;
using UnityGeneticAlgorithm.Solution;

namespace UnityGeneticAlgorithm.Operators {
    public interface IMutationOperation<T> {
        double Probability { get; set; }
		void Execute(ref ISolution<T> solution);
    }
}
