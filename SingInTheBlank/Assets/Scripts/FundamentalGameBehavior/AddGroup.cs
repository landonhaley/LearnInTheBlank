using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddGroup : MonoBehaviour {

	public ScrollRect content;
	public Toggle toggle;

	public void OnClick()
	{
		GUI.Toggle (new Rect (0, 0, 10, 10), false, "Yoooooooo");
	}
}
