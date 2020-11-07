using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour{
	public static bool isPlayerDead = false;
	private Text gameOver;
	
	void Start(){
		gameOver = GetComponent<Text> ();
		gameOver.enabled = false;
	}
	
	void Update(){
		if(isPlayerDead){
			Time.timeScale = 0;
			gameOver.enabled = true;
		}
	}
}