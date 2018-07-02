using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

	public GameObject platformTBSpawned;
	public GameObject diamond;
	public Vector3 position;
	public ballController b;

	
	void Start () {
		position=new Vector3(5.5f, 0f, 4.5f);
		InvokeRepeating("spawnPlatforms", 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		if(b.getDead()){
			CancelInvoke("spawnPlatforms");
		}
	}
	void spawnPlatforms(){
		System.Random rnd = new System.Random();
		int decision=rnd.Next(2);
		if(decision == 0){
			spawnX();
		}else if(decision ==1){
			spawnZ();
		}
		decision=rnd.Next(7);
		if(decision ==5){
			spawnDiamond();
		}
	}
	void spawnX(){
		position.x += 1;
		Instantiate(platformTBSpawned, position,Quaternion.identity);
	}
	void spawnZ(){
		position.z += 1;
		Instantiate(platformTBSpawned, position, Quaternion.identity);
	}
	public void retartSpawninig(){
		InvokeRepeating("spawnPlatforms", 0.1f, 0.1f);
	}
	void spawnDiamond(){
		Vector3 pos=position;
		pos.y=0.5f;
		Instantiate(diamond, pos, Quaternion.Euler(45f,-45f,0f));
	}
}
