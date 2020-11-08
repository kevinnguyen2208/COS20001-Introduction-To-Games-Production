using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Restart game when Space Button is pressed
public class RestartLevel : MonoBehaviour{
	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			PlayerScore.playerScore = 0;
			GameOver.isPlayerDead = false;
			Time.timeScale = 1;
			
			SceneManager.LoadScene("GameStart");//put the name of the start scene here
		}
	}
}