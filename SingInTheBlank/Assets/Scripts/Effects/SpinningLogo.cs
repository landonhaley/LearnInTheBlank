using UnityEngine;
using System.Collections;

public class SpinningLogo : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (gameObject.transform.localEulerAngles.y > 0 && transform.localEulerAngles.y < 91) {
			gameObject.transform.Rotate (Vector3.up * (-1.4f));
		}
	
	}
}
