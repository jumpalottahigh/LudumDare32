using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public float speed = 25f;
	public float jumpSpeed = 25f;
	public float fallSpeed = -0.08f;

	public bool jumping = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//Move forward and back
		float moveBF = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		float moveUD = Input.GetAxis ("Vertical") * jumpSpeed * Time.deltaTime;

		if(moveBF != 0)
			transform.Translate (moveBF, 0, 0);

		if (transform.position.y > 1.5f) {
			transform.Translate (0, -0.18f, 0);
		}

		if (moveUD > 0) {
			if (transform.position.y < 8f) {
				transform.Translate (0, moveUD, 0);
			}
		}



	



	}
}
