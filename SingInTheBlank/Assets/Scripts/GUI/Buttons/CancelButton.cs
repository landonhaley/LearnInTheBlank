using UnityEngine;
using System.Collections;

public class CancelButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick()
	{
		ControlCenter.Instance.LoadMainWindow();
	}
}
