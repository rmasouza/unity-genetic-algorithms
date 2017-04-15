using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityGeneticAlgorithm.Solution {
    public interface ISolution<T> {
        double Fitness { get; set; }
        int Generation { get; set; }
        int Evaluation { get; set; }
		T[] Data { get; }

        int  Compare(ref ISolution<T> sol);
		ISolution<T> Clone();
    }
}
