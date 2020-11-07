using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Restart game when Space Button is pressed
public class RestartLevel : MonoBehaviour{
	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			PlayerScore.playerscore = 0;
			GameOver.isPlayerDead = false;
			Time.timescale = 1;
			
			SceneManager.LoadScene("....");//put the name of the start scene here
		}
	}
}