using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLose : MonoBehaviour{
	private Transform player;
	
	void Start(){
		player = GetComponent<Transform>();
	}
	
	void Update(){
		if(player.childCount == 0){
			GameOver.isPlayerDead = True;
		}
	}
}