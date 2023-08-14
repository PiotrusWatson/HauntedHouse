using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHandler : MonoBehaviour
{
    public float rotationSpeed;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //temp shit
        target = FindNearestZombie();
        transform.rotation = GetRotationToPoint(target);
    }

    GameObject FindNearestZombie(){
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
        GameObject closestZombie = zombies[0];
        float shortestDistance = Vector3.Distance(transform.position, closestZombie.transform.position);

        foreach (GameObject zombie in zombies){
            float distance = Vector3.Distance(transform.position, zombie.transform.position);
            if (distance < shortestDistance){
                shortestDistance = distance;
                closestZombie = zombie;
            }            
        }
        return closestZombie;
    }

    Quaternion GetRotationToPoint(GameObject point){
        Vector3 targetDirection = point.transform.position - transform.position;
        float singleStep = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        return Quaternion.LookRotation(newDirection);
    }
}
