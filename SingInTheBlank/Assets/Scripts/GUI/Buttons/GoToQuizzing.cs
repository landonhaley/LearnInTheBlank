using UnityEngine;
using System.Collections;

public class GoToQuizzing : MonoBehaviour {

	public void OnClick()
	{
		ControlCenter.Instance.LoadQuizzing ();
	}
}
