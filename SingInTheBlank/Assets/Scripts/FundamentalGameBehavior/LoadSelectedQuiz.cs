using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadSelectedQuiz : MonoBehaviour {

	public Text texty;

	// Use this for initialization
	void Start () {
		texty.text = ControlCenter.Instance.quiz.title;
	}

}
