using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NextQuestion : MonoBehaviour {

	Group chosenGroup;
	Word chosenWord;
	string hiddenSentence;
	public Text CurrentGroupName;
	public Text CurrentQuestion;
	public InputField userInput;
	public GameObject NextAns;
	public GameObject SubmitAns;
	public Text QNum;

	public void OnClick(){
		
		//Reset Objects
		userInput.text = "";
		userInput.GetComponentInChildren<Text>().color = Color.black;

		if (ControlCenter.Instance.qnum < ControlCenter.Instance.quiz.questions.Count) {
			//Choose group & quiz
			int idxGroup = ControlCenter.Instance.gnum, idxQuiz = ControlCenter.Instance.qnum;

			//Randomly choose hidden word
			int i = 0;
			List<int> candidates = new List<int> ();
			foreach (Word word in ControlCenter.Instance.quiz.questions[idxQuiz].sentence) {
				if (word.word.Length >= 4)
					candidates.Add (i);
				i++;
			}

			//Save & mark
			int cand = Random.Range (0, candidates.Count);
			int selected = candidates [cand];
			ControlCenter.Instance.chosenGroup = ControlCenter.Instance.quiz.selectedGroups [idxGroup]; //save
			ControlCenter.Instance.chosenWord = ControlCenter.Instance.quiz.questions[idxQuiz].sentence[selected]; //save
			ControlCenter.Instance.hiddenSentence = ControlCenter.Instance.quiz.questions[idxQuiz].getSentence(selected); //save
			ControlCenter.Instance.quiz.questions[idxQuiz].sentence [selected].blank = true; //mark that word as blank

			//Plug data into GUI
			NextAns.GetComponent<Button>().interactable = false;
			NextAns.SetActive (false);
			SubmitAns.GetComponent<Button>().interactable = true;
			SubmitAns.SetActive (true);
			CurrentGroupName.text = ControlCenter.Instance.chosenGroup.groupname;
			CurrentQuestion.text = ControlCenter.Instance.hiddenSentence;
			QNum.text = (ControlCenter.Instance.qnum+1) + ".";
		}

		else{
			ControlCenter.Instance.LoadQuizResults();
		}
	}
}
