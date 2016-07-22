using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class OkAddGroup : MonoBehaviour {

	public Text newGroupName;
	public GameObject bg;
	public GameObject itemPrefab;
	public GameObject content;
	public GameObject scrollbar;

	public void OnClick(){

		if (newGroupName.text != "") {
			adjustGroups ();
			bg.SetActive (false);
			addToggles ();
		}
			
	}


	public void adjustGroups (){

		Group _group = new Group ();
		_group.groupname = newGroupName.text;
		ControlCenter.Instance.groups.Add (_group);
	}

	public void addToggles(){

		Application.LoadLevel(Application.loadedLevel);
	}
}
