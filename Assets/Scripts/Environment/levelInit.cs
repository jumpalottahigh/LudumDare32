using UnityEngine;
using System.Collections;

public class levelInit : MonoBehaviour {

	public float levelSpeed;

	private GameObject player;

	private GameObject currentLastTile;
	private GameObject currentLastSpikeTop;
	private GameObject currentLastSpikeBot;
	private GameObject currentLastSeagullTop;
	private GameObject currentLastSeagullBot;

	//Track x coordinate for the tile spawns
	private float fixedSpawnDistance = 10.0f;
	private float fixedSpawnDistance2 = 20.0f;

	//Track x coords for the spikes
	private float curSpikeTopX = 10.0f;
	private float curSpikeBotX = 10.0f;

	private bool spawnOnce = true;

	// Use this for initialization
	void Start () {
		//instantiate the player
		player = Instantiate (Resources.Load ("Prefabs/Player"), new Vector3 (0, 1.5f, 0), Quaternion.identity) as GameObject;
		player.name = "Player";

		//instantiate light
		Instantiate (Resources.Load ("Prefabs/Light"), Vector3.zero, Quaternion.identity);

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
		//Nicer actual background will go here
		/*
		for (int j=0; j<25; j++) {
			Instantiate(Resources.Load("Prefabs/BackGround"+Random.Range(1,4)), new Vector3(Random.Range(1,100), Random.Range(1, 5),  5f), Quaternion.identity);
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
		//GameMaster
		if(!dieFromFalling.playerDied)
			transform.Translate (Vector3.right * levelSpeed * Time.deltaTime, Space.World);


		//Detect player distance from last tile
		if (Vector3.Distance (player.transform.position, currentLastTile.transform.position) < 30f && spawnOnce) {
			spawnOnce = false;
			SpawnTiles(5);
			SpawnTilesLevel2(5);

			SpawnSpikesBot(5);
			SpawnSpikesTop(5);

		}
	}


	/// <summary>
	/// Spawns the tiles.
	/// </summary>
	/// <param name="amount">Amount.</param>
	
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

				if(Random.value < 0.5f){
					//Spawn seagulls bot
					currentLastSeagullBot = Instantiate(Resources.Load("Prefabs/Seagull"), Vector3.zero + new Vector3(fixedSpawnDistance + (float) Random.Range(1f,11f), 0.5f, 0), Quaternion.identity) as GameObject;
				}

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
				GameObject buffer = Instantiate(Resources.Load("Prefabs/Floor"), Vector3.zero + new Vector3(fixedSpawnDistance2, 8f,0), Quaternion.identity) as GameObject;
				buffer.name = "tile2" + i;

				//Get last tile
				currentLastTile = buffer;

				if(Random.value > 0.5f){
					//Spawn seagulls top
					currentLastSeagullTop = Instantiate(Resources.Load("Prefabs/Seagull"), Vector3.zero + new Vector3(fixedSpawnDistance2 + (float) Random.Range(1f,11f), 8.5f, 0), Quaternion.identity) as GameObject;
				}


			}
			fixedSpawnDistance2 +=10.0f;
			i++;
		}
		//Reenable spawning
		spawnOnce = true;
	}

	//SPIKES
	/// <summary>
	/// Spawns the spikes top.
	/// </summary>
	/// <param name="amount">Amount.</param>
	/// 

	void SpawnSpikesTop(int amount){
		int i = 0;

		float chance = 0.0f;

		while (i< amount) {
			chance = Random.value;
			if(chance > 0.1f){
				//Spawn some spikes at the top
				GameObject buffer = Instantiate(Resources.Load("Prefabs/Spike"+Random.Range(1,4)), Vector3.zero + new Vector3(curSpikeTopX, 18f, 0), Quaternion.identity) as GameObject;

				currentLastSpikeTop = buffer;
			}

			curSpikeTopX +=15.0f;
			i++;
		}
	}

	void SpawnSpikesBot(int amount){
		int i = 0;
		
		float chance = 0.0f;
		
		while (i< amount) {
			chance = Random.value;
			if(chance > 0.55f ){
				//Spawn some spikes at the top
				GameObject buffer = Instantiate(Resources.Load("Prefabs/Spike"+Random.Range(1,4)), Vector3.zero + new Vector3(curSpikeBotX, 0.5f, 0), Quaternion.Euler(new Vector3(0,0,180f))) as GameObject;
				
				currentLastSpikeTop = buffer;
			}

			curSpikeBotX += 15.0f;
			i++;
		}
	}


	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="obj">Object.</param>

	//Garbage Collection
	void OnTriggerEnter(Collider obj){
		Destroy (obj.gameObject);
	}
}
