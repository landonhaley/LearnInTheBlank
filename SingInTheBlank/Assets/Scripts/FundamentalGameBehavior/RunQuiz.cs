using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RunQuiz : MonoBehaviour 
{

	Group chosenGroup;
	Word chosenWord;
	string hiddenSentence;
	public Text CurrentGroupName;
	public Text CurrentQuestion;


	void Start(){
		PrepareQuiz ();
		GenerateQuestion ();
	}

	public void PrepareQuiz()
	{
		//Shuffle Group List
		for (int i=0; i<ControlCenter.Instance.quiz.selectedGroups.Count; i++)
		{
			Group temp_g = ControlCenter.Instance.quiz.selectedGroups [i];
			int idx = Random.Range (i, ControlCenter.Instance.quiz.selectedGroups.Count);
			ControlCenter.Instance.quiz.selectedGroups [i] = ControlCenter.Instance.quiz.selectedGroups [idx];
			ControlCenter.Instance.quiz.selectedGroups [idx] = temp_g;
		}

		//Reset question ticker
		ControlCenter.Instance.qnum = 0;
		ControlCenter.Instance.gnum = 0;

	}
	
	public void GenerateQuestion()
	{
		//Choose group
		int idxGroup = ControlCenter.Instance.gnum;

		//Randomly choose hidden word
		int idxQuiz = ControlCenter.Instance.qnum, i=0;
		List<int> candidates = new List<int> ();
		foreach (Word word in ControlCenter.Instance.quiz.questions[idxQuiz].sentence)
		{
			if (word.word.Length >= 4)
				candidates.Add (i);
			i++;
		}

		//Save & mark
		ControlCenter.Instance.chosenGroup = ControlCenter.Instance.quiz.selectedGroups [idxGroup++]; //save
		ControlCenter.Instance.chosenWord = ControlCenter.Instance.quiz.questions[idxQuiz].sentence[candidates [Random.Range (0, candidates.Count)]]; //save
		ControlCenter.Instance.hiddenSentence = ControlCenter.Instance.quiz.questions[idxQuiz].getSentence(Random.Range (0, candidates.Count)); //save
		ControlCenter.Instance.quiz.questions[idxQuiz].sentence [candidates [Random.Range (0, candidates.Count)]].blank = true; //mark that word as blank

		//Plug data into GUI
		CurrentGroupName.text = ControlCenter.Instance.chosenGroup.groupname;
		CurrentQuestion.text = ControlCenter.Instance.hiddenSentence;

	}

	public void checkSubmission(string input)
	{
		bool answer = (ControlCenter.Instance.userAnswer.ToLower () == ControlCenter.Instance.chosenWord.word.ToLower ());
	}


}