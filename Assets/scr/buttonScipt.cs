﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScipt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void restart(){
		Application.LoadLevel(1);
	}
	public void quit(){
		Application.Quit();
	}
}
