using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/Food")]
public class FoodDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        GameObject food = GameObject.FindWithTag("Food");

        if (food)
        {
            return true;
        }

        return false;
    }
}
