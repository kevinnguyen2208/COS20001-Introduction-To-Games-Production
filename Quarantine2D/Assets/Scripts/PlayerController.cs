using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public AudioClip collisionSound; 

    private Transform player;
    private float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal"); //-1, 0, 1 for left, no input and right. 
        float y = Input.GetAxisRaw("Vertical"); //-1 for down. 

        Vector2 direction = new Vector2(x, y).normalized; //normalized vector is a vector in the same direction but with unit length

        Move(direction);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && (Time.time > nextFire)) //Time.time is the time passed since the beginning of the game 
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);  
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<AudioSource>().PlayOneShot(collisionSound);
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    void Move(Vector2 direction)
    {
        //this gives the maximum a player can move based on the camera. 
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //bottom left 
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //top right

        max.x -= 0.225f; //subtract the player's sprite half-width 
        min.x += 0.225f; //add the player sprite hald-width

        max.y -= 0.285f; //subtract the player's sprite half-height 
        min.y += 0.285f; //add the player sprite hald-height

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;
        //make sure the player is not positioned outside the screen
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }
}
