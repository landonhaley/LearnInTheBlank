using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ReadFiles : MonoBehaviour {

	public List<Group> temp = new List<Group>();

	// Use this for initialization
	void Start () {

		populateGroupList ();
		populateQuiz ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void populateGroupList()
	{
		string filepath = "groups.txt", line;
		FileStream in_file = new FileStream(filepath, FileMode.Open);

		using (StreamReader readFile = new StreamReader(in_file))
		{
			while((line = readFile.ReadLine()) != null)
			{
				Group _group = new Group ();
				_group.groupname = line;
				temp.Add (_group);
			}	
		}

		ControlCenter.Instance.CreateGroups (temp);
		ControlCenter.Instance.num = 9;
	}

	void populateQuiz()
	{

		string[] quizFiles = Directory.GetFiles ("Quizzes");
		foreach (string fileName in quizFiles) 
			loadQuiz (fileName);
		
				


		/*
		string quizpath = "quizzes.txt", quizLine;
		FileStream quiz_in = new FileStream (quizpath, FileMode.Open);

		using (StreamReader quizRead = new StreamReader (quiz_in)) 
		{
			while ((quizLine = quizRead.Readline ()) != null) 
			{
				Quiz _quizzes = new Quiz ();
				_quizzes.title = quizLine;
				ControlCenter.Instance.quizzes.Add (_quizzes);
			}
		}
		*/
	}

	void loadQuiz (string fileName)
	{
		FileStream quiz_in = new FileStream (fileName, FileMode.Open);

		Quiz _quizzes = new Quiz ();
		_quizzes.title = fileName;
		string currentLine;

		using (StreamReader quizRead = new StreamReader (quiz_in)) 
		{
			while ((currentLine = quizRead.ReadLine()) != null) {

				Question _question = new Question();
				_question.setSentence (currentLine);
			}
		}
	}
}
