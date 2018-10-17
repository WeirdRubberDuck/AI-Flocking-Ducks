using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "FSM/Actions/Flee")]
public class FleeAction : Action
{
    public override void Act(StateController controller)
    {
        Vector3 boidPos = controller.transform.position;
        Vector3 enemyPos = controller.boid.enemyPosition.position;

        float distance = Vector3.Distance(boidPos, enemyPos);
        float dangerFactor = 1 - (distance / 6.0f);

        Vector3 vecFromEnemy = Vector3.Normalize(boidPos - enemyPos);

        controller.boid.Move(dangerFactor * vecFromEnemy);
    }
}
