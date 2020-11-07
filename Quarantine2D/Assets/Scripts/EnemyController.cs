using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Transform enemyHolder;
    private float speed = 1;

    //public Text winText;
    public GameObject shot;
    public float fireRate = 0.997f; 

    void Start()
    {
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f); 
        enemyHolder = GetComponent<Transform>();
    }

    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed; 

        foreach(Transform enemy in enemyHolder)
        {
            if (enemy.position.x < -10.5 || enemy.position.x > 10.5)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            //EnemyBulletController 
            if(Random.value > fireRate)
            {
                Instantiate(shot, enemy.position, enemy.rotation); 
            }

            if(enemy.position.y <= -4)
            {
                //GameOver.isPlayerDead = true; 
                Time.timeScale = 0;
                SceneManager.LoadScene("GameOver");
            }

            if(enemyHolder.childCount == 1)
            {
                CancelInvoke();
                InvokeRepeating("MoveEnemy", 0.1f, 0.25f); 
            }
            if(enemyHolder.childCount == 0)
            {
                //winText.enabled = true; 
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
