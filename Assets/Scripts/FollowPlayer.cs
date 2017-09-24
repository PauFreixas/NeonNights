using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Transform player;
	public float hoffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.position.x - hoffset, transform.position.y , transform.position.z);
	}
}
