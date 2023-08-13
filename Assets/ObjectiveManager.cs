using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavigationManager))]
[RequireComponent(typeof(ProtagonistAnimationController))]
public class ObjectiveManager : MonoBehaviour
{
    public GameObject[] objectives;
    public float desiredDistanceFromObjective;
    public float timeToWaitAtObjective;

    NavigationManager navManager;
    ProtagonistAnimationController controller;
    int currentObjectiveIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        navManager = GetComponent<NavigationManager>();
        controller = GetComponent<ProtagonistAnimationController>();
    }

    void Start(){
        navManager.SetDestination(objectives[0].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, objectives[currentObjectiveIndex].transform.position) < desiredDistanceFromObjective){
            controller.ToggleIsSearching(true);
            navManager.Wait(timeToWaitAtObjective);
        }
    }

    public void GoToNextObjective(){
        if (currentObjectiveIndex >= objectives.Length){
            return;
        }
        currentObjectiveIndex += 1;
        navManager.SetDestination(objectives[currentObjectiveIndex].transform.position);
    }
}
