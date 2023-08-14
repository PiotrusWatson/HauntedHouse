using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected GameObject gameObj;
    protected IStateController controller;

    public abstract void Update();

    public abstract void OnStateEnter();
    public virtual void OnFirstStateEnter() {}
    public virtual void OnStateExit() { }

    public State(GameObject gameObj, IStateController controller){
        this.gameObj = gameObj;
        this.controller = controller;
    }
}
