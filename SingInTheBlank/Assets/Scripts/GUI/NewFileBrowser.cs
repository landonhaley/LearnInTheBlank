using UnityEditor;
using System.IO;
using UnityEngine.UI;
using System.Collections;

using UnityEngine;


public class NewFileBrowser : MonoBehaviour
{
	[MenuItem(" Example/Load Textures to Folder")]

	public void Apply()
	{

		GameObject inputFieldGo = GameObject.Find ("InputField");
		InputField inputFieldOb = inputFieldGo.GetComponent<InputField>();

		string path = EditorUtility.OpenFilePanel ("Load Text File", "", "");
		string[] files = Directory.GetFiles (path);

		foreach (string file in files)
			if (file.EndsWith (".txt"))
				inputFieldOb.text = file;
	}

}