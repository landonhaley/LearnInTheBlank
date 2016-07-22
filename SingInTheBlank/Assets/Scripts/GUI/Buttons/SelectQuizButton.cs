using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SelectQuizButton : MonoBehaviour {

	public ToggleGroup toggles;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick()
	{
		findSelectedQuiz ();
	}

	public void findSelectedQuiz(){

		IEnumerable<Toggle> activeToggles = toggles.ActiveToggles();

		foreach (Toggle toggy in activeToggles) {
	
			Text quizLabel = toggy.GetComponentInChildren<Text> ();
			string _quiztitle = quizLabel.text;

			foreach (Quiz _quiz in ControlCenter.Instance.quizzes) {
				
				if (_quiztitle == _quiz.title)
					ControlCenter.Instance.quiz = _quiz;
			}
		}
					
		ControlCenter.Instance.LoadGroupSelect ();
	}
}
