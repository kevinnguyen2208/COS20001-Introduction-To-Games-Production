using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Demo
{
    public class BulletController : MonoBehaviour
    {
        private Transform bullet;
        public float speed;

        void Start()
        {
            bullet = GetComponent<Transform>();
        }

        void FixedUpdate()
        {
            bullet.position += Vector3.up * speed;

            if (bullet.position.y >= 10)
            {
                Destroy(gameObject);
            }
        }

        void OnTriggerEneter2D(Collider2D other)
        {
            if (other.tag == "Virus")
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                PlayerScore.playerScore += 10;
            }
        }
    }
}
