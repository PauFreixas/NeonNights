using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroText : MonoBehaviour {

	public Text title;
	public Text instructions;

	public float apparitiontime;
	public float blinkingspeed;

	private Color color;

	// Use this for initialization
	void Start () {
		color = title.material.color;
		color.a = 0;
		title.material.color = color;
	}
	
	// Update is called once per frame
	void Update () {

		color = title.material.color;
		while (Time.fixedTime < apparitiontime) {
			color.a = Time.fixedTime / apparitiontime;
			title.material.color = color;
		}

		color = instructions.material.color;
		color.a = -Mathf.Cos (Time.fixedTime) + 0.5f;
		instructions.material.color = color;
	}
}
