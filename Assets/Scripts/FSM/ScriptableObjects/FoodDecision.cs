using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/Food")]
public class FoodDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        // If food nearby, return true
        if(controller.boid.foodPosition != null) return true;

        return false;
    }
}
