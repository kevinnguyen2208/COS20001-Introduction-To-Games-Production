using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusBulletController : MonoBehaviour{
	private Transform bullet;
	public float speed;
	
	void Start(){
		bullet = GetComponenet<Transform> ();
	}
	
	void FixedUpdate(){
		bullet.position += Vector3.up * -speed;
		
		if(bullet.position.y <= -10){
			Destroy(bullet.gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			Destroy(other.gameObject);
			Destroy(gameObject);
			GameOver.isPlayerDead = true;
		}
	}
}