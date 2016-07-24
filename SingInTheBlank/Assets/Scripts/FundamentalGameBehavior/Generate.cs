using System.IO;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



public class Generate : MonoBehaviour {

	public Text filePath;

	public void generate()
	{
		//GameObject inputFieldGo = GameObject.Find ("InputField");
		//InputField inputFieldOb = inputFieldGo.GetComponent<InputField> ();



		string path;
		string p1;
		string printPath;
		//string instance;
		string quizDirectory = System.IO.Directory.GetCurrentDirectory() + "/Quizzes/";

		List<string> sentences;
		sentences = upload(filePath.text);
		path = filePath.text;
		p1 = Path.GetFileName (path);
		p1 = Path.ChangeExtension (p1, ".parse");
		Quiz newQuiz = new Quiz ();
		newQuiz.title = Path.GetFileNameWithoutExtension (p1);
		ControlCenter.Instance.quizzes.Add (newQuiz);
		printPath = quizDirectory + p1;

		//printPath = Path.ChangeExtension (printPath, ".parse");
		//print (System.IO.Directory.GetCurrentDirectory());
		//AppDomain.CurrentDomain.BaseDirectory
		FileStream parseFile = new FileStream (printPath, FileMode.Create);
		parseFile.Close();

		using (StreamWriter sw = new StreamWriter(printPath))
		{
			foreach (string s in sentences)
			{
				sw.WriteLine(s);
			}
		}

		//List<Group> temp = 


	}

	List<string> upload(string nameOfFile)
	{
		List<string> sentences = new List<string>();
		if (File.Exists(nameOfFile))
		{
			using (StreamReader sr = File.OpenText(nameOfFile))
			{
				string s = "";
				char currentLetter = ' ';
				while (sr.Peek() >= 0)
				{
					currentLetter = (char)sr.Read();
					if (currentLetter == 65533)
					{
						currentLetter = '\'';
					}

					if (currentLetter == '.')
					{
						s += currentLetter;
						Console.WriteLine(s);
						sentences.Add(s);
						s = "";
					}
					else
					{
						s += currentLetter;
					}
				}
			}
		}
		else
		{
			Console.WriteLine("Error, the selected file was not found");
		}
		return sentences;
	}




}
