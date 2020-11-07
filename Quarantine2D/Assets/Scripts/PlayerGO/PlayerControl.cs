using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerControl : MonoBehaviour
{
    public float speed; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); //-1, 0, 1 for left, no input and right. 
        float y = Input.GetAxisRaw("Vertical"); //-1 for down. 

        Vector2 direction = new Vector2(x, y).normalized; //normalized vector is a vector in the same direction but with unit length

        Move(direction); 
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
