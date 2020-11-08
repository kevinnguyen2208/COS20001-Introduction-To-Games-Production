using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour{
	//public Text scoreText; 
	public static bool isPlayerDead = false;
	private Text gameOver;
	
	void Start(){
		//scoreText = GetComponent<Text>(); 
		gameOver = GetComponent<Text> ();
		gameOver.enabled = false;
	}
	
	void Update(){
		if(isPlayerDead){
			Time.timeScale = 0;
			//scoreText.text = PlayerScore.playerScore.ToString(); 
			gameOver.enabled = true;
		}
	}
}