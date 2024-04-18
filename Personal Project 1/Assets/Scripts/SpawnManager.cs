using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] catchables;
    GameManager gameManager;
    private float spawnStartDelay = 1f, spawnInterval = 1.5f;
    private float xSpawnBoundary = 15;
    private float yTopSpawnBoundary = 2.20f, yBotSpawnBoundary = -3.5f;
    private float zSpawnPos = -0.55f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("SpawnCatchables", spawnStartDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCatchables()
    {
        if (gameManager.gameIsActive)
        {
            // sets a random game object to be spawned
            GameObject spawnedObject = catchables[Random.Range(0, catchables.Length)];

            // Sets a random spawn position from the left and the right side of the scene
            float[] xPos = { -xSpawnBoundary, xSpawnBoundary };
            float xSpawnPos = xPos[Random.Range(0, 2)];
            float ySpawnPos = Random.Range(yTopSpawnBoundary, yBotSpawnBoundary);

            Instantiate(spawnedObject, new Vector3(xSpawnPos, ySpawnPos, zSpawnPos), spawnedObject.transform.rotation);
        }
    }
}
