using UnityEngine;
using System;
using System.Collections.Generic;
[Serializable]
public class Quiz {

	public string title;
	public List<Group> selectedGroups = null;
	public List<Question> questions = null;
	public List<Results> results = null;

}
