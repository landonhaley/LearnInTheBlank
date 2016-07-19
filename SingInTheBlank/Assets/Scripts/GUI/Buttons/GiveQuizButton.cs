using UnityEngine;
using System.Collections;

public class GiveQuizButton : MonoBehaviour {

	public void OnClick()
	{
		ControlCenter.Instance.LoadQuizSelect ();
	}
}
