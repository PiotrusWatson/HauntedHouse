using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : State
{
    NavigationManager navman;
    CombatHandler combatHandler;
    ProtagStateController stateController;
    public CombatState(GameObject gameObj, ProtagStateController controller) : base(gameObj, controller)
    {
        
    }

    public override void OnStateEnter()
    {
        navman = gameObj.GetComponent<NavigationManager>();
        combatHandler = gameObj.GetComponent<CombatHandler>();
        stateController = gameObj.GetComponent<ProtagStateController>();
    }

    public override void Update()
    {
        if (combatHandler.ThereAreZombies()){
            combatHandler.RotateToNearestZombie();
            combatHandler.FireBurst();
        }
        else {
            stateController.GoToObjective();
        }
    }


}
