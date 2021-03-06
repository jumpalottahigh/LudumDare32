﻿using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public float speed = 35f;
	public float jumpForce = 600f;
	public Rigidbody rb;

	public AudioClip tornadoSound;

	public static GameObject tornado;

	public bool grounded = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		//Move forward and back
		float moveBF = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		//float moveUD = Input.GetAxis ("Vertical") * jumpSpeed * Time.deltaTime;

		if(moveBF != 0)
			transform.Translate (moveBF, 0, 0);


		//Add force to jump
		if (Input.GetButtonDown ("Jump")) {
			if(grounded){
				rb.AddRelativeForce(transform.up * jumpForce);

				//transform.Rotate( Vector3.up, 90, Space.Self);
			} 
		}

		//If in air add extra force down
		if (transform.position.y > 8f) {

		}

		//Ground the player if y position is exactly ground level
		if ((transform.position.y >= 1.5f && transform.position.y < 2.5f) || (transform.position.y < 7.5f && transform.position.y >= 6.5f)) {
			grounded = true;
		} else {
			grounded = false;
			rb.AddRelativeForce(transform.up * (-5f));
		}


		//SHOOTING
		if (Input.GetButtonDown ("Fire1") && tornado == null) {
			tornado = Instantiate(Resources.Load("Prefabs/Tornado"), transform.position + new Vector3(3, 0, 0), Quaternion.Euler(Vector3.up)) as GameObject;
			AudioSource.PlayClipAtPoint (tornadoSound, transform.position);

			Invoke("DestroyTornado", 10);
		}

	}

	void DestroyTornado(){
		Destroy (tornado);
	}
}
