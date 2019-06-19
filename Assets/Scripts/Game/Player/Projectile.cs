using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 10f; //travel speed of projectile
    private Rigidbody2D rigid; //reference to rigidbody

    private void Awake()
    {
        //get reference to rigidbody
        rigid = GetComponent<Rigidbody2D>();
    }

    //Fires this bullet in a given direction (using defined speed)
    public void Fire(Vector3 direction)
    {
        //add force in the given direction by speed
        rigid.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //try getting asteroid script from collision
        Asteroid asteroid = collision.GetComponent<Asteroid>();
        //if it is an asteroid
        if (asteroid)
        {
            //destroy the asteroid
            asteroid.Destroy();
            //destroy the projectile
            Destroy(gameObject);
        }
    }
}
