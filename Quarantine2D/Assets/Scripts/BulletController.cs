using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    private Transform bullet;
    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();    
    }

    //fixed Update is time dependent and independent of the framerate. 
    private void FixedUpdate()
    {
        bullet.position += Vector3.up * speed;

        if (bullet.position.y >= 10)
            Destroy(gameObject); //destroy bullet 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject); //bestroy the enemy 
            PlayerScore.playerScore += 10; 
            Destroy(gameObject);  // destroy bullet 
        }
    }
}
