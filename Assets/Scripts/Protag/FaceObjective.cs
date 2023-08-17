using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceObjective : MonoBehaviour
{
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public Quaternion GetRotationToPoint(GameObject point)
    {
        Vector3 targetDirection = point.transform.position - transform.position;
        float singleStep = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        return Quaternion.LookRotation(newDirection);
    }
}
