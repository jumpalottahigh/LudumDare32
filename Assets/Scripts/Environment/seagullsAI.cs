using UnityEngine;
using System.Collections;

public class seagullsAI : MonoBehaviour {

	public float chargeSpeed;

	public AudioClip charge1;
	public AudioClip charge2;
	private bool playing;

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

		playing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, player.transform.position) < 15f) {
			//Charge forward!
			transform.Translate (Vector3.left * chargeSpeed * Time.deltaTime, Space.World);

			if(!playing){
				playOnce();
				playing = true;
			}
			
		}
	}

	void playOnce(){
		if (Random.value < 0.5f) {
			AudioSource.PlayClipAtPoint (charge1, transform.position);
		} else {
			AudioSource.PlayClipAtPoint(charge2, transform.position);
		}

		playing = false;
	}
}
