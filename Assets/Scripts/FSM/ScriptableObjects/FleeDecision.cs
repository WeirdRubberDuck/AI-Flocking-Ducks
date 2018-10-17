using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "FSM/Decisions/Flee")]
public class FleeDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return Danger(controller);
    }

    bool Danger(StateController controller)
    {
        if(controller.player)
        {
            Vector3 enemyPos = controller.player.transform.position;
            Vector3 enemyVelocity = controller.player.GetComponent<Rigidbody>().velocity;
            Vector3 boidPos = controller.transform.position;

            float distance = Vector3.Distance(enemyPos, boidPos);
            float nextDistance = Vector3.Distance(enemyPos + enemyVelocity * Time.deltaTime, boidPos);
            
            float dangerMaxDistance = 6.0f;

            // If enemy is close and enemy moving towards the boid, return true
            if (distance < dangerMaxDistance)
            {
                // Check if enemy is moving towards me
                if (nextDistance < distance)
                    return true;
            }
        }

        return false;

    }
}