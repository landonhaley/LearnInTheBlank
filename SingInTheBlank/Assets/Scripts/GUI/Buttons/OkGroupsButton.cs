using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OkGroupsButton : MonoBehaviour {

	public void OnClick()
	{
		// temp
		List<Group> groups = null;
		ControlCenter.Instance.LoadMainWindow (groups);
	}
}
