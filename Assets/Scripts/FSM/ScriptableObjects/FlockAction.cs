using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "FSM/Actions/Flock")]
public class FlockAction : Action { 

	public override void Act(StateController controller)
    {
        controller.boid.Flock();
    }
}
