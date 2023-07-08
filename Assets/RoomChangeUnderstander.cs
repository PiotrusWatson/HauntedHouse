using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class RoomEvent: UnityEvent<Vector2>{

}

public class RoomChangeUnderstander : MonoBehaviour
{
    public RoomEvent RoomChanged;
    public Vector2 RoomCentre;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c){
        if (c.CompareTag("Player")){
            RoomChanged.Invoke(RoomCentre);
        }
    }
}
