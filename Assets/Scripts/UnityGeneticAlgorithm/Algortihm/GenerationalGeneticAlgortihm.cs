using System.Collections.Generic;
using System.Linq;
using UnityGeneticAlgorithm.Solution;

namespace UnityGeneticAlgorithm.Algorithm {
    public class GenerationalGeneticAlgortihm<T> : AGeneticAlgorithm<T> {
        protected override List<ISolution<T>> ExpandPopulation(List<ISolution<T>> population) {
            List<ISolution<T>> offspringPopulation = new List<ISolution<T>>(PopulationSize);
			if (population == null) {
				throw new System.Exception("Population is null");
			}

            //for(int i = 0; i < PopulationSize; i += 1) 
			while (offspringPopulation.Count < PopulationSize){
                var parents = new List<ISolution<T>>();

                parents.Add(selection.Execute(population));
                parents.Add(selection.Execute(population));

                var offspring = crossover.Execute(ref parents);

                for (int j = 0; j < offspring.Count; j += 1) {
                    var tmp = offspring[j];
                    Mutate(ref tmp);
					offspringPopulation.Add(offspring[j]);
                }
            }
            
            return offspringPopulation;
        }

        protected override List<ISolution<T>> ReplacePopulation(List<ISolution<T>> currentPopulation, 
		                                                     List<ISolution<T>> matingPopulation) {
            currentPopulation.Sort((s1, s2) => s1.Compare(ref s2));
            currentPopulation.Take(2).ToList().ForEach(s => matingPopulation.Add(s));
            matingPopulation.Sort((s1, s2) => s1.Compare(ref s2));

            matingPopulation.Remove(matingPopulation.Last());
            matingPopulation.Remove(matingPopulation.Last());

            return matingPopulation;
        }
    }
}
