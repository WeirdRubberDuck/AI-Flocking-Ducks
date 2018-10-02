using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

	public float neighborRadius = 5.0f;
	public float speed = 0.1f;

	private Rigidbody rb; 
	//private Vector3 course;
	private Vector3 velocity; 

	private List<GameObject> neighbors;

	// Initialization
	void Start () {
		neighbors = new List<GameObject>();
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateNeighbors ();
	}

	// Find other boids within a given radius using collision
	void UpdateNeighbors() {

		Collider[] neighborColliders = Physics.OverlapSphere (transform.position, neighborRadius);

		for(int i = 0; i < neighborColliders.Length; ++i) {
            GameObject neighbor = neighborColliders[i].gameObject;
            if (neighbor.CompareTag("Boid") && neighbor != this.gameObject)
                neighbors.Add(neighborColliders[i].gameObject);
		}
	}

	public void Flock() {

        Debug.Log("Flocking...");

        Vector3 v1 = Cohesion();
        Vector3 v2 = Separation();
        Vector3 v3 = Alignment();

        velocity = v1 + v2 + v3;

        Debug.Log(velocity);

        float step = speed * Time.deltaTime ;
        transform.position = Vector3.MoveTowards(transform.position, velocity, step);
    }

	Vector3 Cohesion() {

        if(!(neighbors.Count > 0)) {
            // TODO: Default behaviour if no neighbors
            return Vector3.zero;
        }

        // Compute average goal
        Vector3 goal = Vector3.zero;
        foreach (GameObject buddy in neighbors) {
			goal += buddy.transform.position;           
		}
		goal /= neighbors.Count;
		return goal * 0.001f; // TODO: Make this factor a variable
	}

    Vector3 Separation()
    {
        Vector3 goal = Vector3.zero;
        foreach (GameObject buddy in neighbors)
        {
            float distance = Vector3.Distance(buddy.transform.position, transform.position);
            if (distance < 1.0f) // TODO: Make factor a variable
            {
                goal -= buddy.transform.position - transform.position;
            }
        }
        return goal;
    }

    Vector3 Alignment()
    {
        Vector3 goal = Vector3.zero;
        // TODO: Implement
        return goal;
    }


}
