using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

//	public float separationRadius = 2.0f;
//	public float cohesionRadius = 10.0f;
//	public float alignmentRadius = 2.0f;
	public float neighborRadius = 5.0f;
	public float speed = 0.5f;

	private Rigidbody rb; 
	private Vector3 course;
	private Vector3 velocity; 

	private int maxNeighbors = 10;
	private GameObject[] neighbors;


	// Use this for initialization
	void Start () {
		neighbors = new GameObject[maxNeighbors];
		rb = GetComponent<Rigidbody> ();

		// Test: initial velocity
		if (rb) rb.velocity = Vector3.right;

		UpdateNeighbors ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateNeighbors ();
		rb.velocity = Vector3.right;
	}

	// Find other boids close to the boid using collision
	void UpdateNeighbors() {

		Collider[] neighborColliders = Physics.OverlapSphere (transform.position, neighborRadius);

		for(int i = 0; i < neighborColliders.Length && i < maxNeighbors; ++i) {
			
			neighbors [i] = neighborColliders [i].gameObject;
		}
	}

	void Flocking() {
		// Sum result of cehesion 
	}

	Vector3 Cohesion() {
		Vector3 goal = Vector3.zero;

		// TEST IF NO NEIGHBORS?

		foreach(GameObject buddy in neighbors) {
			goal += buddy.transform.position;
		}
		// Compute average position
		goal /= neighbors.Length;
		return goal;
	}


}
