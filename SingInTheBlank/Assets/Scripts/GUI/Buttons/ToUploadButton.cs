using UnityEngine;
using System.Collections;

public class ToUploadButton : MonoBehaviour {

	public void OnClick()
	{
		ControlCenter.Instance.LoadUpload ();
	}
}
