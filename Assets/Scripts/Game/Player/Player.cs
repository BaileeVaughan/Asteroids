using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject projectilePrefab; //prefab to spawn when shooting

    public float movementSpeed = 10f;
    public float rotationSpeed = 360f;
    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    //shoots a projectile in a set direction
    void Shoot()
    {
        //spawn projectile at position and rotation of player
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        //get rigidbody2d from projectile
        Projectile bullet = projectile.GetComponent<Projectile>();
        bullet.Fire(transform.up);
    }

    void Control()
    {
        //if player presses space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //shoot a projectile
            Shoot();
        }
        //If the Up key is pressed
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //add upward force
            rigid.AddForce(transform.up * movementSpeed);
        }
        //if down key is pressed
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigid.AddForce(transform.up * -movementSpeed);
        }
        //if left key is pressed
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rotate counterclockwise per second
            rigid.rotation += rotationSpeed * Time.deltaTime;
        }
        //if right key is pressed
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid.rotation += -rotationSpeed * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Control();
    }
}
