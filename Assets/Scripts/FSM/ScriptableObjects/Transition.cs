using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Transition  {

    public Decision decision;
    public State trueState;     // If decision returns true, go to this state
    public State falseState;    // If decision return false.. 
}
