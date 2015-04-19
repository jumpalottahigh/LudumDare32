using UnityEngine;
using System.Collections;

public class dieFromFalling : MonoBehaviour {

	public static bool playerDied;
	private MeshRenderer player;
	private GameObject explode;

	void Start(){
		playerDied = false;
	}

	void OnTriggerEnter(Collider obj){
		if (obj.CompareTag ("Player")) {
			playerDied = true;
			explode = Instantiate(Resources.Load("Prefabs/Explosion"), new Vector3(obj.transform.position.x, obj.transform.position.y, -1f), Quaternion.identity) as GameObject;
			explode.transform.SetParent(obj.transform);

			player = obj.GetComponentInParent<MeshRenderer>();
			Transform plTransf = obj.GetComponentInParent<Transform>();

			plTransf.Rotate(25f,15f,10f);

			Invoke("DestroyPlayer", 3);
		}

		if (this.CompareTag("Spike") && obj.CompareTag ("Tornado")) {
			DestroySpikeORSeagull();
		}

		if (this.CompareTag ("Seagull") && obj.CompareTag ("Tornado")) {
			DestroySpikeORSeagull();
		}
	}

	void DestroySpikeORSeagull(){
		score.addExtraPts = true;
		Destroy (this.gameObject);
	}

	void DestroyPlayer(){
		if (player != null) {
			Destroy (player);
			Destroy(explode);
		}

		Invoke ("Restart", 1);
	}

	void OnGUI(){
		if (playerDied) {
			GUI.Label(new Rect(Screen.width/2 - 100, Screen.height/2, 250, 150), "<color=red><size=44>GET REKT\nSON!</size></color>");
		}
	}

	void Restart(){
		Application.LoadLevel ("level");
	}
}
