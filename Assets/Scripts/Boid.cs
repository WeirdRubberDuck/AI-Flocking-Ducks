using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

	public float neighborRadius = 5.0f;
	public float speed = 0.5f;

	private Rigidbody rb; 
	public Vector3 velocity; 

	private List<GameObject> neighbors;

	// Initialization
	void Start () {
		neighbors = new List<GameObject>();
		rb = GetComponent<Rigidbody> ();

        // Set initial velocity
        velocity = Vector3.zero; //new Vector3(Random.Range(-2.0f, 2.0f), 0.0f, Random.Range(-2.0f, 2.0f));
	}

	// Find other boids within a given radius using collision with a sphere
	void UpdateNeighbors() {

		neighbors.Clear ();

		Collider[] neighborColliders = Physics.OverlapSphere (transform.position, neighborRadius);

		for(int i = 0; i < neighborColliders.Length; ++i)
        {
            GameObject neighbor = neighborColliders[i].gameObject;

            // Make sure the object is a boid and not itself
            if (neighbor.CompareTag("Boid") && neighbor != this.gameObject)
                neighbors.Add(neighborColliders[i].gameObject);
		}
			
	}

    public Vector3 GetVelocity()
    {
        return velocity;
    }

    // Flocking behaviour. Three rules:
    // Cohesion:    Steer to move toward the average position of local flockmates
    // Separation:  Steer to avoid crowdning local flockmates
    // Alignment:   Steer towards the average heading of local flockmates
    public void Flock() {

		UpdateNeighbors ();

        Vector3 cohesionVec = Vector3.zero;
        Vector3 separationVec = Vector3.zero;
        Vector3 alignmentVec = Vector3.zero;

        if (neighbors.Count > 0)
        {
            Vector3 avgGroupPos = Vector3.zero;
            Vector3 velocityDiff = Vector3.zero;

            foreach (GameObject buddy in neighbors)
            {
                // Cohesion contribution:
                avgGroupPos += buddy.transform.position;

                // Separation contribution
                float distance = Vector3.Distance(buddy.transform.position, transform.position);
                if (distance < 1.5f) // TODO: Make factor a variable
                {
                    separationVec += (transform.position - buddy.transform.position); // Move boid away from buddy
                }

                // Alignment contribution
                velocityDiff += (buddy.GetComponent<Boid>().GetVelocity() - velocity);
            }

            avgGroupPos /= neighbors.Count;
            velocityDiff /= neighbors.Count;

            Debug.Log("avgGroupPos: " + avgGroupPos + " \n");

            // TODO: Make constants for the factor
           cohesionVec = (avgGroupPos - transform.position) * 0.002f;
            separationVec = separationVec * 1;
            alignmentVec = (velocityDiff - transform.position) * 0.005f;
        }

        Debug.Log( neighbors.Count + "Neighbors \n"
                + "Cohesion  : " + cohesionVec.ToString("F4") + "\n"
                + "Separation: " + separationVec.ToString("F4") + "\n"
                + "Alignment : " + alignmentVec.ToString("F4") + "\n");

        // PROBLEM!! Once they form a group they start moving back and forth.. Why??

        velocity = velocity + cohesionVec + separationVec + alignmentVec;
        velocity.y = 0.0f; // Don't want to move in y

        float step = speed * Time.deltaTime ;

		transform.position += velocity * step;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, velocity, 5*step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red); // Test: to see front of 

        transform.rotation = Quaternion.LookRotation(newDir);
    }

}
