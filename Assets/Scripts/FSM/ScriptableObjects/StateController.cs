using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For NavMeshAgent
using UnityEngine.AI;

public class StateController : MonoBehaviour {

    // For testing - remove later
    [HideInInspector]
    public List<Vector3> wayPointList;
    [HideInInspector]
    public int nextWayPoint;

    public State currentState;
    public State remainState;

    void Awake()
    {
        wayPointList[0] = Vector3.zero;
        wayPointList[1] = new Vector3(5.0f, 0.5f, 5.0f);
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }
    }

    private void OnDrawGizmos()
    {
        if(currentState != null)
        {
            // See what state the agent is in based on color of gizmo
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(transform.position, 2.0f); // TODO: variable for radius
        }
    }

    public void TransitionToState(State nextState)
    {
        if(nextState != remainState)
        {
            currentState = nextState;
        }
    }
}
