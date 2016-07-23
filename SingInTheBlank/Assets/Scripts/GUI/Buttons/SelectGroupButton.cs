using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SelectGroupButton : MonoBehaviour {

	public ToggleGroup toggles;

	// Use this for initialization
	void Start () {
		print(ControlCenter.Instance.quiz.title);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick()
	{
		findSelectedGroups ();
	}

	public void findSelectedGroups(){

		IEnumerable<Toggle> activeToggles = toggles.ActiveToggles();
		List<Group> _groups = new List<Group> ();

		foreach (Toggle toggy in activeToggles) {
			Group groupy = new Group();
			Text groupLabel = toggy.GetComponentInChildren<Text> ();
			string _groupname = groupLabel.text;
			groupy.groupname = _groupname;
			_groups.Add (groupy);
		}

		ControlCenter.Instance.quiz.selectedGroups = _groups;
		ControlCenter.Instance.LoadQuizOverview ();
	}
}
