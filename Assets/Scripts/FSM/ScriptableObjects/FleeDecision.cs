using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "FSM/Decisions/Flee")]
public class FleeDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        if (controller.boid.enemyPosition) {
            Vector3 enemyPos = controller.boid.enemyPosition.position;
            Vector3 boidPos = controller.transform.position;
            float distance = Vector3.Distance(enemyPos, boidPos);

            // If enemy is close, return true
            float dangerMaxDistance = 6.0f;

            // TODO: Check if enemny if moving towards me
            if (distance < dangerMaxDistance)
            {
                return true;
            }
        }

        return false;
    }
}