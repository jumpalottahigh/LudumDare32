using UnityEngine;
using System.Collections;

public class dieFromFalling : MonoBehaviour {

	private bool playerDied = false;

	void OnTriggerEnter(Collider obj){
		if (obj.CompareTag ("Player")) {
			playerDied = true;
			Invoke("Restart", 2);
		}
	}

	void OnGUI(){
		if (playerDied) {
			GUI.Label(new Rect(Screen.width/2 - 100, Screen.height/2, 250, 50), "<color=red><size=44>You died!</size></color>");
		}
	}

	void Restart(){
		Application.LoadLevel ("level");
	}
}
