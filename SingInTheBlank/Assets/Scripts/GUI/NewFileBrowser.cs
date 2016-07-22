using UnityEditor;
using System.IO;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using UnityEngine;


public class NewFileBrowser : MonoBehaviour
{
	[MenuItem(" Example/Load Textures to Folder")]



	public void Apply()
	{

		GameObject inputFieldGo = GameObject.Find ("InputField");
		InputField inputFieldOb = inputFieldGo.GetComponent<InputField> ();

		string path = EditorUtility.OpenFilePanel ("Load Text File", "", "");
		string[] files = Directory.GetFiles (path);


		foreach (string file in files)
			if (file.EndsWith (".txt")) {
				inputFieldOb.text = file;

				//print (file);
				//sentence = createParse (newPath);
				/*
				printPath = newPath;
				printPath = Path.ChangeExtension (printPath, ".parse");
				print (printPath);
				//printPath = path.Replace (initPath, initPath + ".parse");
				FileStream parseFile = new FileStream ("../../../Quizzes/" + printPath, FileMode.Create);
				*/
			}



	}

	public void createParse()
	{
		//InputField inputFieldOb = inputFieldGo.GetComponent<InputField> ();
		//string path;
		//string printPath;
		//List<string> sentence;
		//path = inputFieldOb.text;
		//printPath = path;
		//printPath = Path.ChangeExtension (printPath, ".parse");
		//FileStream parseFile = new FileStream (printPath, FileMode.Create);

		
	}

		




}