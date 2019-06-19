using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public GameObject[] asteroidPieces; //pieces of asteroids to spawn
    public int spawnAmount = 4;
    public float maxVelocity = 3f;
    
    //spawns random asteroid in random direction
    void Spawn()
    {
        //generate random index into asteroid pieces array
        int randomIndex = Random.Range(0, asteroidPieces.Length);

        //select random asteroid piece
        GameObject asteroidPiece = asteroidPieces[randomIndex];

        //ask the asteroid manager to spawn a new asteroid piece at a position
        AsteroidManager.Spawn(asteroidPiece, transform.position);
    }

    public void Destroy()
    {
        //destroy self
        Destroy(gameObject);

        //if there are assigned asteroids pieces
        if (asteroidPieces.Length > 0)
        {
            //loop throught the specified spawn amount
            for (int i = 0; i < spawnAmount; i++)
            {
                //spawn an asteroid
                Spawn();
            }
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
