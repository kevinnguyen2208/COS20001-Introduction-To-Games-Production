using UnityEngine; 
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


namespace Demo
{
    public class PlayerScore : MonoBehaviour
    {
        public static float playerScore = 0;
        private Text scoreText;

        void Start()
        {
            scoreText = GetComponent<Text>();
        }

        void Update()
        {
            scoreText.text = "Score: " + playerScore;
        }
    }
}