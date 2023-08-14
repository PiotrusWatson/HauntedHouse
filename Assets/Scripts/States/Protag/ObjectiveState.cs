using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveState : State
{
    NavigationManager navman;
    ObjectiveManager objectiveMan;
    public ObjectiveState(GameObject gameObj, ProtagStateController controller) : base(gameObj, controller)
    {
    }

    public override void OnStateEnter()
    {
        navman = gameObj.GetComponent<NavigationManager>();
        objectiveMan = gameObj.GetComponent<ObjectiveManager>();
        objectiveMan.GoToObjective();
    }

    public override void Update()
    {
        if (objectiveMan.IsCloseToObjective()){
            objectiveMan.WaitAtObjective();
        }
    }

    // Start is called before the first frame update
}
