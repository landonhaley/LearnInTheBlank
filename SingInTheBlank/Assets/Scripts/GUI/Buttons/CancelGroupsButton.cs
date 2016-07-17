using UnityEngine;
using System.Collections;

public class CancelGroupsButton : MonoBehaviour {

	public void OnClick()
	{
		ControlCenter.Instance.LoadMainWindow ();
	}
}
