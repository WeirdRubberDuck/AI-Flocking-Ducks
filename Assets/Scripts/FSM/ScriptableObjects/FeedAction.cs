using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/Feed")]
public class FeedAction : Action
{
    public override void Act(StateController controller)
    {
        Vector3 boidPos = controller.transform.position;
        Vector3 foodPos = controller.boid.foodPosition.position;

        float distance = Vector3.Distance(boidPos, foodPos);

        if(distance > 0.5) // TODO: Make variable
        {
            Vector3 vecToFood = (foodPos - boidPos);
            controller.boid.Move(vecToFood);
        }
        else {
            controller.boid.Stop();
        }
    }
}
