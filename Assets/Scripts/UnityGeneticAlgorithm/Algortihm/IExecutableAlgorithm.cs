using System;
namespace UnityGeneticAlgorithm.Algorithm {
	public interface IExecutableAlgorithm {
		IGeneticAlgorithmEventHandle EventHandle {
			get;
			set;
		}

		bool ShouldStop {
			get;
		}
		void StartRunning();
		void StopRunning();
		void Update();
	}
}
