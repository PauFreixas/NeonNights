using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HeroController : MonoBehaviour {

	public int level;
	public Rigidbody2D rb;
	public float jumpspeed;
	public float walkspeed;
	public int airjumps = 1;

	private Animator anim;

	private int nextLevel;
	private Vector3 start;

	private int jumps;
	private bool grounded = true;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Debug.Log ("CurrentLvl:" + level + "TotalLvls:" + SceneManager.sceneCountInBuildSettings);
		nextLevel = level + 1;
		start = transform.position;
		jumps = airjumps + 1;
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		Vector3 move = new Vector3 (Input.GetAxis("Horizontal"),0,0);
		transform.position += move * walkspeed * Time.deltaTime;

		//Look and walk right
		if (Input.GetKey (KeyCode.RightArrow)) {
			Vector2 theScale = transform.localScale;
			theScale.x = 1;
			transform.localScale = theScale;
			anim.SetTrigger("Walk");
		}

		//Look and walk left
		if (Input.GetKey (KeyCode.LeftArrow)) {
			Vector2 theScale = transform.localScale;
			theScale.x = -1;
			transform.localScale = theScale;
			anim.SetTrigger("Walk");
		}

		//Jump
		if (Input.GetKeyDown (KeyCode.UpArrow) && (grounded == true || jumps > 0)) {
			jumps--;
			rb.AddForce (new Vector3 (0, jumpspeed, 0));
		}

		//Debug.Log ("Jumps:" + jumps + "Grounded:" + grounded);
	}

	void OnCollisionEnter2D (Collision2D col) {

		if (col.collider.gameObject.tag == "NeonCube" || col.collider.gameObject.tag == "NeonWall") {
			grounded = true;
			jumps = 2;
			Debug.Log ("Neon");
		}

		if (col.collider.gameObject.tag == "Deadly") {
			Debug.Log ("GameOver");
			transform.position = start;
		}

		if (col.collider.gameObject.tag == "Finish") {
			
			if (level < SceneManager.sceneCountInBuildSettings - 1) {
				SceneManager.LoadSceneAsync ("Level" + nextLevel);
			} else {
				SceneManager.LoadSceneAsync ("MainMenu");
			}
		}

	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.tag == "Deadly") {
			Debug.Log ("GameOver");
			transform.position = start;
			//SceneManager.LoadSceneAsync ("");
		}

		if (other.gameObject.tag == "CigMachine") {
			Debug.Log ("Saved");
			start = other.gameObject.transform.position;
		}
		if (other.tag == "Untagged") {	
			grounded = true;
			jumps = 1;
		}
		if (other.tag == "NeonCube") {
			jumps = 2;
			Debug.Log ("NeonTrigger");
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		grounded = false;
		if (other.tag != "NeonCube") {
			jumps = 0;
		} 
	}
}
