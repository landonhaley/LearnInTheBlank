using UnityEngine;
using System.Collections;

public class ToGroupsButton : MonoBehaviour {

	public void OnClick()
	{
		ControlCenter.Instance.LoadGroups ();
	}
}
