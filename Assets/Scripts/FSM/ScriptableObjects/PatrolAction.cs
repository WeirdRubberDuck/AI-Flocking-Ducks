using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "FSM/Actions/Patrol")]
public class PatrolAction : Action { 

	public override void Act(StateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(StateController controller)
    {
        Vector3 destination = controller.wayPointList[controller.nextWayPoint];
        controller.transform.position = Vector3.MoveTowards(controller.transform.position, destination, 3*Time.deltaTime);

        float distance = Vector3.Distance(controller.transform.position, destination);

        if (distance < 1)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
        }
    }
}
