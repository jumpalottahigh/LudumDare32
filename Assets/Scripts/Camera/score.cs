using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {

	public Texture2D tornadoUp;

	public static bool addExtraPts;

	private float scorePoints;

	private bool help;
	private float timer;

	// Use this for initialization
	void Start () {
		help = true;
		timer = 0.0f;

		addExtraPts = false;

		scorePoints = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!dieFromFalling.playerDied) {
			scorePoints += 1 * Time.deltaTime;

			if(addExtraPts){
				scorePoints +=50;
				addExtraPts = false;
			}
		}

		if (timer < 4.0f) {
			timer += 1 * Time.deltaTime;
		} else {
			help = false;
		}
	}

	void OnGUI(){
		//Score and highschore HUD
		GUI.Label (new Rect (Screen.width-200, 50, 200, 50), "<color=yellow><size=34>SCORE: "+(int)scorePoints+"</size></color>");
		GUI.Label (new Rect (20, 50, 500, 50), "<color=blue><size=34>HIGH SCORE: 450</size></color>");

		//Show help explaination for 4 secs
		if (help) {
			GUI.Label(new Rect(Screen.width/2 - 150, Screen.height/2-80, 250, 150), "<color=white><size=24>Press space to jump\nLMB to shoot a tornado</size></color>");
		}

		//Testing texture positions
		if (movement.tornado == null) {
			GUI.Label(new Rect(Screen.width/2 - 64, 20, 64, 64), tornadoUp);
		}

	}
}
