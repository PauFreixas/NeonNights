using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public Transform player;
	public Rigidbody2D rb;
	public float speed;

	public Shot(Transform player) {
		this.player = player;
	}

	// Use this for initialization
	void Start () {
		Vector2 force = new Vector2 (player.position.x - transform.position.x, player.position.y - transform.position.y);
		force.Normalize ();
		rb.AddForce (force * speed);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col) {
		Destroy (this.gameObject);
	}
}
