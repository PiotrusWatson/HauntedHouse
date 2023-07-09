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
        cam = GetComponent<Camera>();
        zombieSpawnTimer.amount = spawnCooldown;
    }

    void Start(){
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(){
        Spawner spawner = FindVisibleSpawner();
        Debug.Log("The spawner is!!!" + spawner.name);
        if (canSpawn && spawner != null){
            spawner.SpawnThing();
            canSpawn = false;
            
        }
        

    }

    public Spawner FindVisibleSpawner(){
        foreach (GameObject spawny in spawners){
            RaycastHit hitinfo;
           Ray ray = cam.ViewportPointToRay(cam.WorldToViewportPoint(spawny.transform.position));
           if (Physics.Raycast(ray, out hitinfo)){
            if (hitinfo.collider.CompareTag("Spawner")){
                return spawny.GetComponent<Spawner>();
            }
            
           }
        }
        return null;
    }
}
