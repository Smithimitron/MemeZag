using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamondScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){
		col.GetComponentInParent<ScoreManagerr>().addScore(5);
		col.GetComponentInParent<ScoreManagerr>().reportChange();
		col.GetComponentInParent<ballController>().speed += 0.5f;
		Destroy(gameObject);
	}
}
