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

	//Return string of full sentence
	public string getSentence (int idx)
	{
		int i = 0;
		string temp = "";
		foreach (Word wordy in sentence)
		{
			if (idx == i++)
				temp += "___ ";
			else
				temp += wordy.word + " ";
		}
		return temp.Trim();
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
