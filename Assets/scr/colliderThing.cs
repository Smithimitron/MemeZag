using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderThing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider s){
		if(s.gameObject.tag == "Player"){
			s.GetComponentInParent<ScoreManagerr>().addScore(1);
			s.GetComponentInParent<ScoreManagerr>().reportChange();
		}
	}
	void OnTriggerExit(Collider t){
		if(t.gameObject.tag == "Player"){
			makeFallOff();
		}
	}
	void makeFallOff(){
		GetComponentInParent<Rigidbody>().isKinematic=false;
		GetComponentInParent<Rigidbody>().useGravity=true;
		Invoke("dest", 5f);
	}
	void dest(){
		Destroy(gameObject);
	}
}
