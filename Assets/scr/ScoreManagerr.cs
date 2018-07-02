using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerr : MonoBehaviour {

	public Text s;
	private int score;
	private int highScore;
	public Text score_final_text, highscore_final_text;
	
	// Use this for initialization
	void Start () {
		s.gameObject.SetActive(true);
		score = 0;
		if(PlayerPrefs.HasKey("High Score")){
			highScore = PlayerPrefs.GetInt("High Score");
		}
		else{
			highScore=0;
			PlayerPrefs.SetInt("High Score", 0);
		}
		s.text="Score: 0";
	}
	public void addScore(int scoreToAdd){
		score += scoreToAdd;
	}
	
	// Update is called once per frame
	void Update () {
		bool dead = GetComponentInParent<ballController>().getDead();
		if (dead){
			//set high score if it is larger than prev
			int previousHS = PlayerPrefs.GetInt("High Score");
			if(score>previousHS){
				PlayerPrefs.SetInt("High Score", score);
				highScore=score;	
			}
		}
	}
	public int getScore(){
		return score;
	}
	public int getHighScore(){
		return highScore;
	}
	public void reportChange(){
		s.text="Score: "+score;
	}
	public void tellMeToShutDown(){
		s.gameObject.SetActive(false);
		score_final_text.text="Score: " +score.ToString();
		highscore_final_text.text="High Score: "+highScore.ToString();

	}
	
}
