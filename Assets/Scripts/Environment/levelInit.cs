using UnityEngine;
using System.Collections;

public class levelInit : MonoBehaviour {

	private GameObject currentLastTile;
	private GameObject player;
	private float fixedSpawnDistance = 0.0f;

	private bool spawnOnce = true;

	// Use this for initialization
	void Start () {


		//instantiate the player
		player = Instantiate (Resources.Load ("Prefabs/Player"), new Vector3 (0, 1.5f, 0), Quaternion.identity) as GameObject;
		player.name = "Player";

		//Spawn 5 tiles
		SpawnTiles (5);

		//Spawning background for reference
		for (int j=0; j<25; j++) {
			Instantiate(Resources.Load("Prefabs/BackGround"+Random.Range(1,4)), new Vector3(Random.Range(1,100), Random.Range(1, 5),  5f), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Detect player distance from last tile
		if (Vector3.Distance (player.transform.position, currentLastTile.transform.position) < 20f && spawnOnce) {
			spawnOnce = false;
			SpawnTiles(5);
		}
	}

	void SpawnTiles(int amount){
		int i = 0;

		float chance = 0.0f;

		while (i<amount) {
			chance = Random.value;
			if(chance < 0.5f || chance > 0.75f){
				//Spawn floor tiles
				GameObject buffer = Instantiate(Resources.Load("Prefabs/Floor"), Vector3.zero + new Vector3(fixedSpawnDistance, 0,0), Quaternion.identity) as GameObject;
				buffer.name = "tile" + i;
				
				//Get last tile
				currentLastTile = buffer;
			}
			fixedSpawnDistance +=20.0f;
			i++;
		}
		//Reenable spawning
		spawnOnce = true;
	}
}
