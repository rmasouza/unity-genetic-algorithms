using System;
using System.Collections.Generic;
using UnityGeneticAlgorithm.Solution;

namespace UnityGeneticAlgorithm.Operators {
    public interface ISelectionOperator<T> {
        ISolution<T> Execute(List<ISolution<T>> population);
    }
}
