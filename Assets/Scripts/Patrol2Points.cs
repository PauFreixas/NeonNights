using UnityEngine;
using System.Collections;

public class Patrol2Points : MonoBehaviour {

	public Vector2 displacement;
	public float speed = 1;

	private Vector2 start;
	private float step;
	// Use this for initialization
	void Start () {
		start = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		step = -Mathf.Cos (Time.fixedTime * speed) + 1;
		transform.position = new Vector2 (start.x + step*displacement.x, start.y + step * displacement.y); 
	}
}
