using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    //on spawn - start cooldown
    public float spawnCooldown;
    public Morale zombieSpawnTimer;
    List<GameObject> spawnedStuff;
    Camera cam;
    
    

    bool canSpawn = true;

    IEnumerator HandleSpawnCoolDown(){
        for (int timer = 0; timer < spawnCooldown; timer++){
            yield return new WaitForSeconds(1);
            zombieSpawnTimer.amount -= 1;
        }
        canSpawn = true;
        
    }
    GameObject[] spawners;
    // Start is called before the first frame update
    void Awake()
    { 
        //cam = GetComponent<Camera>();
        zombieSpawnTimer.amount = spawnCooldown;
    }

    void Start(){
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Spawn(){
        if (canSpawn){
            Spawner spawner = FindVisibleSpawner();
            if (spawner == null){
                return false;
            }
            zombieSpawnTimer.amount = spawnCooldown;
            spawner.SpawnThing();
            canSpawn = false;
            StartCoroutine(HandleSpawnCoolDown());
            return true;
        }
        return false;
        
        

    }

//this is now slower oops
    public Spawner FindVisibleSpawner(){
        GameObject closestSpawner = null;
        float closestSpawnerDistance = Vector3.Distance(Camera.main.transform.position, spawners[0].transform.position);
        foreach (GameObject spawny in spawners){
            Vector3 viewportSpawnerPos = Camera.main.WorldToViewportPoint(spawny.transform.position);
            
            //is the thing outside of the camera viewport???
            if (viewportSpawnerPos.x < 0 || viewportSpawnerPos.x > 1 || viewportSpawnerPos.y < 0 || viewportSpawnerPos.y > 1){
            //ok it isn't so lets check if its closer than what we have so far
            } else {
                float spawnerDistance = Vector3.Distance(Camera.main.transform.position, spawny.transform.position);
                if (spawnerDistance <= closestSpawnerDistance){
                    closestSpawner = spawny;
                    closestSpawnerDistance = spawnerDistance;
                }

            }
        
        }
        return closestSpawner.GetComponent<Spawner>();
    }
}
