using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBulletController : MonoBehaviour
{

    private Transform bullet;
    public float speed;
    public AudioClip bulletShot;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
        GetComponent<AudioSource>().PlayOneShot(bulletShot);
    }

    private void FixedUpdate()
    {
        bullet.position += Vector3.up * -speed; 

        if(bullet.position.y <= -10)
            Destroy(bullet.gameObject); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            //GameOver.isPLayerDead = true; 
            SceneManager.LoadScene("GameOver");
        }
    }
}
