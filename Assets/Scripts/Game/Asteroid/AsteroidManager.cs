using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    //singleton
    public static AsteroidManager Instance;
    void Awake()
    {
        Instance = this;
    }


    public GameObject[] asteroidPrefabs; //array of prefabs to spawn
    public float maxVelocity = 3f; //max velocity an asteroid can move
    public float spawnRate = 1f; //rate of spawn
    public float spawnPadding = 2f; //padding to spawn
    public Color debugColor = Color.green;

    //Spawns an asteroid at a position specified
    public static void Spawn(GameObject prefab, Vector3 position)
    {
        //Randomize a rotation of the asteroid
        Quaternion randomRot = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        //spawn random asteroid at random position and default Quaternion
        GameObject asteroid = Instantiate(prefab, position, randomRot, Instance.transform);

        //get rigidbody2d from asteroid
        Rigidbody2D rigid = asteroid.GetComponent<Rigidbody2D>();

        //apply random force to rigidbody
        Vector2 randomForce = Random.insideUnitCircle * Instance.maxVelocity;
        rigid.AddForce(randomForce, ForceMode2D.Impulse);
    }

    //spawns a random asteroid in the array at a random position
    void SpawnLoop()
    {
        //get cameras bounds using extension method
        Bounds camBounds = Camera.main.GetBounds(spawnPadding);

        //randomize a position within a circle
        Vector2 randomPos = camBounds.GetRandomPosOnBounds();

        //generate random index into asteroids prefabs array
        int randomIndex = Random.Range(0, asteroidPrefabs.Length);

        //get random asteroid prefab from array using index
        GameObject randomAsteroid = asteroidPrefabs[randomIndex];

        //spawn using random pos
        Spawn(randomAsteroid, randomPos);
    }

    void Start()
    {
        //Invoke a function repeatedly with given rate
        InvokeRepeating("SpawnLoop", 0, spawnRate);
    }

    void OnDrawGizmos()
    {
        Bounds camBounds = Camera.main.GetBounds(spawnPadding);
        Gizmos.color = debugColor;
        Gizmos.DrawWireSphere(transform.position, spawnPadding);
    }

    void Update()
    {

    }
}
