using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {

    // For testing - remove later
    [HideInInspector] public List<Vector3> wayPointList;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Boid boid;

    public State currentState;
    public State remainState;

    void Start()
    {
        boid = GetComponent<Boid>();
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
