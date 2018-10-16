using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "FSM/Decisions/Stop")]
public class StopDecision : Decision {

    public override bool Decide(StateController controller)
    {
        Debug.Log(Time.time);
        if (Time.time > 3.0f) return true;

        return false;
    }
}
