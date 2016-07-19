using UnityEngine;
using System.Collections;

public class ToQuizzesButton : MonoBehaviour {

	public void OnClick()
	{
		ControlCenter.Instance.LoadQuizzes ();
	}
}
