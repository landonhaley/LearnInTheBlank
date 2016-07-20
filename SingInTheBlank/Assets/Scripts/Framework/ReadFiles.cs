using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ReadFiles : MonoBehaviour {

	// Use this for initialization
	void Start () {

		populateGroupList ();
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
				ControlCenter.Instance.groups.Add (_group);
			}	
		}
	}
}
