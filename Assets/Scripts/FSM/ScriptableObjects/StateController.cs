using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {

    [HideInInspector] public FoodSource currentFoodSource;
    [HideInInspector] public Boid boid;
    [HideInInspector] public GameObject player;

    public State currentState;
    public State remainState;



    void Start()
    {
        boid = GetComponent<Boid>();
        currentFoodSource = null;
        player = GameObject.FindWithTag("Player");
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

    public GameObject FindClosestFood()
    {
        GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");

        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject food in foods)
        {
            Vector3 diff = food.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = food;
                distance = curDistance;
            }
        }

        return closest;
    }
}
