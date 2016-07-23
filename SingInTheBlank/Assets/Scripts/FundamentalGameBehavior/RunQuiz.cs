using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RunQuiz : MonoBehaviour 
{

	Group chosenGroup;
	Word chosenWord;
	string hiddenSentence;
	
	public void GenerateQuestion()
	{
		int idxGroup, idxWord;
		Quiz mainQuiz = ControlCenter.Instance.quiz;

		//Shuffle Group List
		idxGroup = 0;
		List<Group> gList = mainQuiz.selectedGroups;
		for (int i = 0; i < gList.Count; i++) 
		{
			Group temp = gList [i];
			idxGroup = Random.Range (i, gList.Count);
			gList [i] = gList [idxGroup];
			gList [idxGroup] = temp;
		}
			
		foreach (Question question in mainQuiz.questions) 
		{			
			//Choose group
			chosenGroup = gList [idxGroup++ % gList.Count];

			//Randomly choose hidden word
			int i = 0;
			List<int> candidates = new List<int>();
			foreach (Word word in question.sentence)
			{
				if (word.word.Length >= 4)
					candidates.Add (i);
				i++;
			}
			idxWord = candidates [Random.Range (0, candidates.Count)];
			question.sentence [idxWord].blank = true;
			chosenWord = question.sentence[idxWord];

			//Generate sentence string
			hiddenSentence = question.getSentence(idxWord);


			//At this point, we have the data to plug into GUI

		}
	}

	public bool checkCorrect()
	{
		string answer = "correct"; //replace this with what user inputted
		bool check;

		return (answer.ToLower () == chosenWord.word.ToLower ());
	}
}