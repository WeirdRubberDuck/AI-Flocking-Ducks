using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/Feed")]
public class FeedAction : Action
{
    public override void Act(StateController controller)
    {
        FeedAtClosestFood(controller);  
    }

    void FeedAtClosestFood(StateController controller)
    {
        GameObject closest = controller.FindClosestFood();

        if(closest)
        {
            Vector3 foodPos = closest.transform.position;
            Vector3 boidPos = controller.transform.position;
            float distance = Vector3.Distance(boidPos, foodPos);

            if (distance > 1.0f) // TODO: Make variable
            {
                Vector3 vecToFood = (foodPos - boidPos);
                controller.boid.MoveByVector(vecToFood);
            }
            else
            {
                controller.boid.Stop();
            }
        }

    }

}
