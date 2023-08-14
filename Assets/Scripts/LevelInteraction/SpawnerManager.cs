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

    public Spawner FindVisibleSpawner(){
        foreach (GameObject spawny in spawners){
            Vector3 viewportSpawnerPos = Camera.main.WorldToViewportPoint(spawny.transform.position);
            if (viewportSpawnerPos.x < 0 || viewportSpawnerPos.x > 1 || viewportSpawnerPos.y < 0 || viewportSpawnerPos.y > 1){

            } else{
                return spawny.GetComponent<Spawner>();
            }
        
        }
        return null;
    }
}
