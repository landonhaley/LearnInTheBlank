using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class DeleteQuiz : MonoBehaviour {

	public ToggleGroup toggles;

	public void OnClick()
	{
		adjustQuizzes ();
		deleteToggles ();
	}

	public void deleteToggles(){

		IEnumerable<Toggle> activeToggles = toggles.ActiveToggles();
		string dir = Directory.GetCurrentDirectory () + "\\Quizzes\\";

		foreach (Toggle toggy in activeToggles) {
			Text quizLabel = toggy.GetComponentInChildren<Text> ();
			string _quiztitle = dir + quizLabel.text + ".parse";
			File.Delete (_quiztitle);
			Destroy (GameObject.Find (toggy.name));
		}

	}

	public void adjustQuizzes(){

		GameObject[] gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];

		for (int i=0; i < gameObjects.Length; i++){

			if(gameObjects[i].name.Contains("Quiz")){

				if (gameObjects[i].GetComponent<UnityEngine.UI.Toggle>().isOn){

					Text quizLabel = gameObjects[i].GetComponent<UnityEngine.UI.Toggle>().GetComponentInChildren<Text> ();
					string _quiztitle = quizLabel.text;

					foreach (Quiz _quiz in ControlCenter.Instance.quizzes) {

						if (_quiztitle == _quiz.title) {
							ControlCenter.Instance.quizzes.Remove (_quiz);
							break;
						}
					}
				}
			}
		}
			
		Application.LoadLevel(Application.loadedLevel);
	}
}
