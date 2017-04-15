
using System;
using UnityGeneticAlgorithm.UI;
using UnityEngine;
using UnityGeneticAlgorithm.Algorithm;

namespace UnityGeneticAlgorithm {
	public class GeneticAlgorithmRunner : MonoBehaviour {
		private IExecutableAlgorithm ga = null;
		private bool isRunning = false;

		private static GeneticAlgorithmRunner _instance = null;
		public static GeneticAlgorithmRunner Instance {
			get {
				if (_instance == null) {
					_instance = FindObjectOfType<GeneticAlgorithmRunner>();
				}
				return _instance;
			}
		}

		public IExecutableAlgorithm Ga {
			get {
				return ga;
			}

			set {
				ga = value;
				print("Setting GA");
			}
		}

		void Start() {
			print("HELLO BOY");
		}

		void Update() {
			if (!isRunning) { return; } else if (ga.ShouldStop) { return; }

			print("RUN");

		}

		public void Run() {
			if (Ga == null) {
				throw new NullReferenceException("AGeneticAlgorithm can't be null.");
			}

			print("GeneticAlgorithmRunner is Running. " + gameObject.GetInstanceID());
			Ga.StartRunning();
			isRunning = true;
		}

		public void Stop() {
			print("GeneticAlgorithmRunner is not Running anymore. " + gameObject.GetInstanceID());
			isRunning = false;
			Ga.StopRunning();
		}
	}
}
