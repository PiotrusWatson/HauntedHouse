using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveToRoom : MonoBehaviour
{
    public float moveSpeed;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target, moveSpeed * Time.smoothDeltaTime);
    }

    public void MoveRooms(Vector3 newTarget){
        target = new Vector3(newTarget.x, transform.position.y, newTarget.z);
    }
}
