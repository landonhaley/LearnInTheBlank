using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DeleteGroup : MonoBehaviour {

	public ToggleGroup toggles;

	public void OnClick()
	{
		adjustGroups ();
		deleteToggles ();
	}

	public void deleteToggles(){

		IEnumerable<Toggle> activeToggles = toggles.ActiveToggles();

		foreach (Toggle toggy in activeToggles) {
			Text groupLabel = toggy.GetComponentInChildren<Text> ();
			string _groupname = groupLabel.text;
			Destroy (GameObject.Find (toggy.name));
		}
		
	}

	public void adjustGroups(){

		List<Group> _groups = new List<Group> ();

		GameObject[] gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
		print ("WAH"+ gameObjects.Length);

		for (int i=0; i < gameObjects.Length; i++){
			
			if(gameObjects[i].name.Contains("Group")){
				
				if (!(gameObjects[i].GetComponent<UnityEngine.UI.Toggle>().isOn)){
					
					Group groupy = new Group();
					Text groupLabel = gameObjects[i].GetComponent<UnityEngine.UI.Toggle>().GetComponentInChildren<Text> ();
					string _groupname = groupLabel.text;
					groupy.groupname = _groupname;
					_groups.Add(groupy);
					print ("hey");
				}
			}
		}

		ControlCenter.Instance.groups = _groups;
		print (_groups.Count);
	}
}
	