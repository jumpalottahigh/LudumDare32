using UnityEngine;
using System.Collections;

public class tornadoScript : MonoBehaviour {

	public float speed;
	public float rotSpeed;

	// Use this for initialization
	void Start () {
		speed = 4f;
		rotSpeed = 250f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0f, rotSpeed * Time.deltaTime,0f, Space.Self );
		transform.Translate (Vector3.right * speed * Time.deltaTime, Space.World);
	}
}
