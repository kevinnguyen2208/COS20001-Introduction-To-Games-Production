using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Demo
{
    public class OnCollisionDie : MonoBehaviour
    {
        void Start()
        {

        }

        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Player")
            {
             
                Destroy(other.gameObject);
                Destroy(gameObject);
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}