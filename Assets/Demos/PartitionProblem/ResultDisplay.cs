using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGeneticAlgorithm.Solution;

namespace Demos.PartitionProblem {
	public class ResultDisplay : MonoBehaviour, ISolutionDisplay {
		float left = 0;
		float right = 0;

		NumberSet currentNumberSet;

		[SerializeField]
		Text leftSum;

		[SerializeField]
		Text rightSum;

		[SerializeField]
		Text diferente;

		[SerializeField]
		Image leftSumGraph;

		[SerializeField]
		Image rightSumGraph;

		float Total {
			get {
				return (float)(left + right);
			}
		}

		private static ResultDisplay _instance = null;
		public static ResultDisplay Instance {
			get {
				if (_instance == null) {
					_instance = FindObjectOfType<ResultDisplay>();
				}
				return _instance;
			}
		}

		void Start() {
			leftSumGraph.fillAmount = 0.0f;	
			rightSumGraph.fillAmount = 0.0f;
		}

		void Update() {
			if (Math.Abs(left - currentNumberSet.leftSum) > 0.0) {
				left = Mathf.Lerp((float)left, (float)currentNumberSet.leftSum, 1.0f * Time.deltaTime);
				right = Mathf.Lerp((float)right, (float)currentNumberSet.rightSum, 1.0f * Time.deltaTime);


				leftSumGraph.fillAmount = Mathf.Lerp(leftSumGraph.fillAmount, 
				                                     (float)(left * 100) / Total, 1.0f * Time.deltaTime);

				rightSumGraph.fillAmount = Mathf.Lerp(leftSumGraph.fillAmount,
													 (float)(right * 100) / Total, 1.0f * Time.deltaTime);

				leftSum.text = left.ToString();
				rightSum.text = right.ToString();
			}
		}

		public void ShowSolution(object solution) {
			currentNumberSet = (NumberSet)solution;
		}
	}
}
