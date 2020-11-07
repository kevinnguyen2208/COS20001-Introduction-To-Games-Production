using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour{
	void Start(){
		
	}
	
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Enemy"){
			Destroy(gameObject);
		}
	}
}