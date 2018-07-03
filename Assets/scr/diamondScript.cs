using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamondScript : MonoBehaviour {
	// Use this for initialization
	public AudioClip[]clips;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
		col.GetComponentInParent<ScoreManagerr>().addScore(5);
		col.GetComponentInParent<ScoreManagerr>().reportChange();
		col.GetComponentInParent<ScoreManagerr>().reportDiamond();
		col.GetComponentInParent<ballController>().speed += 0.5f;
		AudioSource s=gameObject.AddComponent<AudioSource>();
		System.Random rnd=new System.Random();
		int t=rnd.Next(clips.Length);
		gameObject.GetComponent<AudioSource>().clip=clips[t];
		gameObject.GetComponent<AudioSource>().playOnAwake=true;
		Destroy(gameObject);
		}
	}
}
