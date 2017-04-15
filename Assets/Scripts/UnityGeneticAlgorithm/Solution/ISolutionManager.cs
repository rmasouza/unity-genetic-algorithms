using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityGeneticAlgorithm.Solution {
    public interface ISolutionManager<T> {
        ISolution<T> CreateSolution();
		double Evaluate(ref ISolution<T> solution);
    }
}
