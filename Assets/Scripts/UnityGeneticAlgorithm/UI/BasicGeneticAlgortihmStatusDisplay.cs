using System;
using UnityEngine.UI;
using UnityEngine;

namespace UnityGeneticAlgorithm.UI {
	public class BasicGeneticAlgortihmStatusDisplay: MonoBehaviour, IGeneticAlgorithmStatusDisplay {
		public Text iterationType;
		public Text currentIteration;
		public Slider iterationSlider;

		private static BasicGeneticAlgortihmStatusDisplay _instance = null;
		public static BasicGeneticAlgortihmStatusDisplay Instance {
			get {
				if (_instance == null) {
					_instance = FindObjectOfType<BasicGeneticAlgortihmStatusDisplay>();
				}
				return _instance;
			}
		}

		public void UpdateIteration(int iteration) {
			iterationSlider.value = iteration;
		}

		public void SetIterationType(string type) {
			iterationType.text = type;
		}

		public void SetMaxIteration(int max) {
			iterationSlider.maxValue = max;
		}
	}
}
