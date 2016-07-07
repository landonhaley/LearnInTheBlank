using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Question : MonoBehaviour {

	public List<Word> sentence;
	public string userAnswer;
	private string actualAnswer;


	/*checks the user's answer*/
	public bool answerCorrect()
	{
		return false;
	}

	public bool displayActualAnswer()
	{
		return false;
	}

}
