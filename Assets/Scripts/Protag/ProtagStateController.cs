using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagStateController : MonoBehaviour, IStateController
{
    private State currentState;
    // Start is called before the first frame update
    void Start()
    {
        SetState(new ObjectiveState(gameObject, this));
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();
    }

    public void SetState(State state){
        if (currentState != null){
            currentState.OnStateExit();
        }

        currentState = state;
        
        if (currentState != null){
            currentState.OnStateEnter();
        }
    }
}
