using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;


[Serializable]
public class Question{
	public List<Word> sentence = new List<Word> ();
	public string userAnswer;
	private string actualAnswer;

	public void setSentence (string _sentence)
	{
		string[] words = _sentence.Split (' ');
		foreach (string s in words) {
			Word _word = new Word ();
			_word.word = s;
			sentence.Add (_word);
		}
	}

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
