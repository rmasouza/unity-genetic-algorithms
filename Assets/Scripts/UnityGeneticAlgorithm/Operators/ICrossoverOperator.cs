using System;
using System.Collections.Generic;
using UnityGeneticAlgorithm.Solution;

namespace UnityGeneticAlgorithm.Operators {
    public interface ICrossoverOperator<T> {
        double Probability { get; set; }
        List<ISolution<T>> Execute (ref List<ISolution<T>> parents);
    }
}
