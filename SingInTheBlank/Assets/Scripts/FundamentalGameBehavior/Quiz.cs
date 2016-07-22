using UnityEngine;
using System;
using System.Collections.Generic;
[Serializable]
public class Quiz {

	public string title;
	public List<Group> selectedGroups = new List<Group> ();
	public List<Question> questions = new List<Question> ();
	public List<Results> results = new List<Results> ();

}
