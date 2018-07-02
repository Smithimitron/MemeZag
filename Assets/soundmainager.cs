using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmainager : MonoBehaviour {

	public AudioSource ali_a;
	public AudioSource nope, intro;
	public ballController ball;
	bool played=false;
	bool songPlaying=true, introFinished;
	// Use this for initialization
	void Start () {
		Invoke("playSong", intro.clip.length-0.15f);
	}
	
	// Update is called once per frame
	void Update () {
		if(ball.getDead()==true && !played){
			nope.Play();
			played=true;
		}
	}
	void playSong(){
		ali_a.Play();
	}
}
