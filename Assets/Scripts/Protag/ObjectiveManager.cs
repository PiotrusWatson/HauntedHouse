using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavigationManager))]
[RequireComponent(typeof(ProtagonistAnimationController))]
[RequireComponent(typeof(FaceObjective))]
public class ObjectiveManager : MonoBehaviour
{
    public GameObject[] objectives;
    public float desiredDistanceFromObjective;
    public float timeToWaitAtObjective;

    NavigationManager navManager;
    ProtagonistAnimationController controller;
    int currentObjectiveIndex = 0;
    FaceObjective faceObjective;

    // Start is called before the first frame update
    void Awake()
    {
        navManager = GetComponent<NavigationManager>();
        controller = GetComponent<ProtagonistAnimationController>();
    }

    void Start(){
        faceObjective = GetComponent<FaceObjective>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public bool IsCloseToObjective(){
        return Vector3.Distance(transform.position, objectives[currentObjectiveIndex].transform.position) < desiredDistanceFromObjective;
    }
    
    public void GoToNextObjective(){
        if (currentObjectiveIndex >= objectives.Length){
            return;
        }
        currentObjectiveIndex += 1;
        navManager.SetDestination(objectives[currentObjectiveIndex].transform.position);
    }

    public void Init(){
        navManager.SetDestination(objectives[0].transform.position);
    }

    public void GoToObjective(){
        Debug.Log(navManager);
        Debug.Log(objectives[currentObjectiveIndex]);
        navManager.SetDestination(objectives[currentObjectiveIndex].transform.position);
    }

    public void WaitAtObjective(){
        transform.rotation = faceObjective.GetRotationToPoint(objectives[currentObjectiveIndex]);
        controller.ToggleIsSearching(true);
        navManager.Wait(timeToWaitAtObjective);
    }


}
