using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjSpawner : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject cube;
    public int objCounter = 0;
    float time = 0f;

    void Update()
    {
        if (objCounter < 30)
        {
            int randomIndex = Random.Range(0, objects.Length);
            Vector3 randomSpawnPoint = new Vector3(Random.Range(-20, 20) - Random.Range(-5, 5), 2.5f, Random.Range(-20, 20) - Random.Range(-5, 5));
            
            Instantiate(objects[randomIndex], randomSpawnPoint, Quaternion.identity);

            objCounter++;
        }
    }

    void FixedUpdate()
    {
        time = Time.fixedTime;
        
        //Makes cubes be sapwned every 10 secs
        if (time % 10 == 0)
        {
            SpawnCube();
        }
    }

    //Spawns a Cube
    void SpawnCube()
    {
        Vector3 randomSpawnPoint = new Vector3(Random.Range(-20, 20) - Random.Range(-5, 5), 1.5f, Random.Range(-20, 20) - Random.Range(-5, 5));

        Instantiate(cube, randomSpawnPoint, Quaternion.identity);
    }

    //Decrease variable so it opens a slot for another object to be spawned
    public void DecreaseObjCounter() 
    {
        objCounter--;
    }
}
