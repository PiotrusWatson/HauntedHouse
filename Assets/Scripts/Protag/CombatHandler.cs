using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FieldOfView))]
[RequireComponent(typeof(FaceObjective))]
[RequireComponent(typeof(GunManager))]
public class CombatHandler : MonoBehaviour
{
    FaceObjective faceObjective;
    public float rotationSpeed;
    Transform target;
    public float delayBetweenFiring;
    FieldOfView fieldOfView;
    GunManager gunManager;

    // Start is called before the first frame update
    void Start()
    {
        fieldOfView = GetComponent<FieldOfView>();
        faceObjective = GetComponent<FaceObjective>();
        gunManager = GetComponent<GunManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //temp shit

    }

    Transform FindNearestZombie(){
        Transform[] zombies = fieldOfView.GetVisibleZombies();
        Transform closestZombie = zombies[0];
        float shortestDistance = Vector3.Distance(transform.position, closestZombie.position);

        foreach (Transform zombie in zombies){
            float distance = Vector3.Distance(transform.position, zombie.position);
            if (distance < shortestDistance){
                shortestDistance = distance;
                closestZombie = zombie;
            }            
        }
        return closestZombie;
    }

    public void RotateToNearestZombie(){
        target = FindNearestZombie();
        transform.rotation = faceObjective.GetRotationToPoint(target.gameObject);
    }

    public bool ThereAreZombies(){
        return fieldOfView.ThereAreZombies();
    }

    public void FireBurst(){
        gunManager.FireBullets();
    }

    

}
