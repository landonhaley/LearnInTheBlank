using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
	Image image;
	public Color c;
	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		c = image.color;
		if (c.a > 0) {
			c.a = c.a - 0.3f;
			image.color = c;
		} else {
			Destroy (gameObject);
		}
	}
}
