using UnityEngine;
using System.Collections;

public class levelInit : MonoBehaviour {

	private GameObject player;

	private GameObject currentLastTile;
	private GameObject currentLastSpikeTop;
	private GameObject currentLastSpikeBot;

	private float fixedSpawnDistance = 10.0f;
	private float fixedSpawnDistance2 = 40.0f;

	private bool spawnOnce = true;

	// Use this for initialization
	void Start () {
		//instantiate the player
		player = Instantiate (Resources.Load ("Prefabs/Player"), new Vector3 (0, 1.5f, 0), Quaternion.identity) as GameObject;
		player.name = "Player";

		//Spawn start tiles
		Instantiate (Resources.Load ("Prefabs/Floor"), new Vector3(-20, 0,0) , Quaternion.identity);
		Instantiate (Resources.Load ("Prefabs/Floor"), Vector3.zero, Quaternion.identity);



		//Spawn 5 tiles
		SpawnTiles (5);
		SpawnTilesLevel2 (5);

		//Spawn spikes
		SpawnSpikesTop (5);
		SpawnSpikesBot (5);

		//Spawning background for reference
		for (int j=0; j<25; j++) {
			Instantiate(Resources.Load("Prefabs/BackGround"+Random.Range(1,4)), new Vector3(Random.Range(1,100), Random.Range(1, 5),  5f), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Detect player distance from last tile
		if (Vector3.Distance (player.transform.position, currentLastTile.transform.position) < 30f && spawnOnce) {
			spawnOnce = false;
			SpawnTiles(5);
			SpawnTilesLevel2(5);
			SpawnSpikesBot(5);
			SpawnSpikesTop(5);
		}
	}

	void SpawnTiles(int amount){
		int i = 0;

		float chance = 0.0f;

		while (i<amount) {
			chance = Random.value;
			if(chance < 0.75f){
				//Spawn floor tiles
				GameObject buffer = Instantiate(Resources.Load("Prefabs/Floor"), Vector3.zero + new Vector3(fixedSpawnDistance, 0,0), Quaternion.identity) as GameObject;
				buffer.name = "tile" + i;

				//Get last tile
				currentLastTile = buffer;
			} else {
				//spawn DeathZone; if player fall they die
				Instantiate(Resources.Load("Prefabs/DeathZone"), Vector3.zero + new Vector3(fixedSpawnDistance, -8f, 0), Quaternion.identity);
			}
			fixedSpawnDistance +=10.0f;
			i++;
		}
		//Reenable spawning
		spawnOnce = true;
	}

	void SpawnTilesLevel2(int amount) {
		int i = 0;
		
		float chance = 0.0f;

		while (i<amount) {
			chance = Random.value;
			if(chance < 0.65f){
				//Spawn floor tiles
				GameObject buffer = Instantiate(Resources.Load("Prefabs/Floor"), Vector3.zero + new Vector3(fixedSpawnDistance2, 5f,0), Quaternion.identity) as GameObject;
				buffer.name = "tile2" + i;
				
				//Get last tile
				currentLastTile = buffer;
			}
			fixedSpawnDistance2 +=10.0f;
			i++;
		}
		//Reenable spawning
		spawnOnce = true;
	}

	void SpawnSpikesTop(int amount){
		int i = 0;

		float chance = 0.0f;

		while (i< amount) {
			chance = Random.value;
			if(chance > 0.1f){
				//Spawn some spikes at the top
				GameObject buffer = Instantiate(Resources.Load("Prefabs/Spike"+Random.Range(1,4)), Vector3.zero + new Vector3(10f*i, 12f, 0), Quaternion.identity) as GameObject;

				currentLastSpikeTop = buffer;
			}

			i++;
		}
	}

	void SpawnSpikesBot(int amount){
		int i = 0;
		
		float chance = 0.0f;
		
		while (i< amount) {
			chance = Random.value;
			if(chance > 0.05f ){
				//Spawn some spikes at the top
				GameObject buffer = Instantiate(Resources.Load("Prefabs/Spike"+Random.Range(1,4)), Vector3.zero + new Vector3(10f*i, 0.5f, 0), Quaternion.Euler(new Vector3(0,0,180f))) as GameObject;
				
				currentLastSpikeTop = buffer;
			}
			
			i++;
		}
	}
}
