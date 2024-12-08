using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    //WILL SPAWN SHEEP PREFABS. ATTACH TO PLAYERNETWORKING

    public GameObject[] spawnPoints;
    public GameObject[] sheepPrefabs;
    private SheepController[] sheepInScene;

    private int herdlessSheep; //tracks the number of sheep without herds in the scene using GetDiscoverable()
    private int spawnIndex = 0;
    private int sheepIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //prefabs already placed in scene. no need to spawn at start
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sheepInScene = GameObject.FindObjectsOfType<SheepController>();

        foreach(SheepController sheep in sheepInScene)
        {
            if (sheep.GetDiscoverable() == true)
            {
                herdlessSheep ++;
            }
        }

        if(herdlessSheep < 5)
        {
            if(spawnIndex < spawnPoints.Length - 1 && sheepIndex < sheepPrefabs.Length - 1)
            {
                Instantiate(sheepPrefabs[sheepIndex], spawnPoints[spawnIndex].transform.position, spawnPoints[spawnIndex].transform.rotation);
                spawnIndex++;
                sheepIndex++;
            }
            else if (sheepIndex < sheepPrefabs.Length - 1)
            {
                spawnIndex = 0;
                Instantiate(sheepPrefabs[sheepIndex], spawnPoints[spawnIndex].transform.position, spawnPoints[spawnIndex].transform.rotation);
                spawnIndex++;
                sheepIndex++;
            }
            else if (spawnIndex < spawnPoints.Length - 1)
            {
                sheepIndex = 0;
                Instantiate(sheepPrefabs[sheepIndex], spawnPoints[spawnIndex].transform.position, spawnPoints[spawnIndex].transform.rotation);
                spawnIndex++;
                sheepIndex++;
            }
            else
            {
                sheepIndex = 0;
                spawnIndex = 0;
                Instantiate(sheepPrefabs[sheepIndex], spawnPoints[spawnIndex].transform.position, spawnPoints[spawnIndex].transform.rotation);
                spawnIndex++;
                sheepIndex++;
            }

            //Spawn rotating sheep prefab at rotating spawn point
            // MAKE SURE THAT THE ANIMATION LOOP MAKES THEM MOVE AWAY FROM SPAWN POINTS. look @ AUTOMOVER, also consider randomly invoking animations in SheepController
        }
    }
}
