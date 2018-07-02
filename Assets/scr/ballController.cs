using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballController : MonoBehaviour {

	bool rolling = false;
	bool dead=false;
	public bool hasControl=false;
	public GameObject pS;
	public float speed=5;
	public Rigidbody rb;
	public GameObject mainCam;
	public AudioSource intro;
	float protectSpeed;
	public GameObject GameOverPane;
	// Use this for initialization
	void Start () {
		Invoke("giveControl", intro.clip.length+0.2f);
	}
	void giveControl(){
		hasControl=true;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)&&hasControl){
			changeDir();
		}
		else{
			maintainspeed();
		}
		RaycastHit info;
		if(!Physics.Raycast(rb.position, Vector3.down) && !dead){
			fall();
			dead=true;
		}
		if(Physics.Raycast(rb.position, Vector3.down) && dead){
			// unFall();
			// dead=false;//i guess ur undead now
		}
	}
	void changeDir(){
		if(rolling){
				if(rb.velocity.x > 0){
					Vector3 vel=rb.velocity;
					vel.x = 0;
					vel.z = speed;
					rb.velocity=vel;
				}else if( rb.velocity.z > 0){
					Vector3 vel=rb.velocity;
					vel.z = 0;
					vel.x = speed;
					rb.velocity=vel;
				}
			}else{
				Vector3 vel=rb.velocity;
				vel.x = speed;
				rb.velocity=vel;
				rolling = true;
			}
	}
	void fall(){
		protectSpeed=speed;
		rb.useGravity=true;
		rb.constraints=RigidbodyConstraints.None;
		Invoke("gameOver", 2f);
	}
	void gameOver(){
		Destroy(gameObject);
		GameOverPane.SetActive(true);
		GetComponent<ScoreManagerr>().tellMeToShutDown();
	}
	public bool getDead(){
		return dead;
	}
	void maintainspeed(){
		if(rb.velocity.x > 0){
			Vector3 st=rb.velocity;
			st.x=speed;
			rb.velocity=st;
		}else if(rb.velocity.z >0){
			Vector3 st=rb.velocity;
			st.z=speed;
			rb.velocity=st;
		}
	}
}
