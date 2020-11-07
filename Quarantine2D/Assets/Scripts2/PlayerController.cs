using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Demo
{
    public class PlayerController : MonoBehaviour
    {
        private Transform player;
        public float speed;
        public float max, min;

        //public GameObject shot;
        //public Transform shotSpawn;
        //public float fireRate;

        private float nextFire;

        void Start()
        {
            player = GetComponent<Transform>();
        }

        void FixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");
            float u = Input.GetAxis("Vertical");

            if (player.position.x < min && h < 0)
                h = 0;
            else if (player.position.x > max && h > 0)
                h = 0;
            else if (player.position.y > max && u > 0)
                u = 0;

            player.position += Vector3.right * h * speed;
            player.position += Vector3.right * u * speed;
        }
    }
}