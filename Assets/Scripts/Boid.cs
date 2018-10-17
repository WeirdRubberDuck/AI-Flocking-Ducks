using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

	public float speedFactor = 0.5f;
    public float maxSpeed = 2.0f;
    public Vector3 velocity;

    public float cohesionFactor = 0.01f;
    public float separationFactor = 0.5f;
    public float alignmentFactor = 0.01f;

    public float neighborRadius = 5.0f;
    public float separationDistance = 1.5f;

    private Rigidbody rb; 
	private List<GameObject> neighbors;

	// Initialization
	void Start () {
		neighbors = new List<GameObject>();
		rb = GetComponent<Rigidbody> ();

        // Set initial velocity
        velocity = Vector3.zero; 
	}

    private void Update()
    {
        UpdateNeighbors();
    }


    void UpdateNeighbors() {

		neighbors.Clear ();

        // Find other boids within a given radius using collision with a sphere
        Collider[] neighborColliders = Physics.OverlapSphere (transform.position, neighborRadius);

		for(int i = 0; i < neighborColliders.Length; ++i)
        {
            GameObject neighbor = neighborColliders[i].gameObject;

            // Make sure the object is a boid and not itself
            if (neighbor.CompareTag("Boid") && neighbor != this.gameObject)
            {
                neighbors.Add(neighborColliders[i].gameObject);
                continue;
            }
        }
	}

    // Flocking behaviour. Three rules:
    // Cohesion:    Steer to move toward the average position of local flockmates
    // Separation:  Steer to avoid crowdning local flockmates
    // Alignment:   Steer towards the average heading of local flockmates
    public void Flock() {

		//UpdateNeighbors ();

        Vector3 cohesionVec = Vector3.zero;
        Vector3 separationVec = Vector3.zero;
        Vector3 alignmentVec = Vector3.zero;

        // If no neighbors, walk randomly
        if (neighbors.Count == 0)
        {
            velocity += new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f));
            Move();
            return;
        }

        Vector3 avgGroupPos = Vector3.zero;
        Vector3 velocityDiff = Vector3.zero;

        foreach (GameObject buddy in neighbors)
        {
            // Cohesion contribution:
            avgGroupPos += buddy.transform.position;

            // Separation contribution
            float distance = Vector3.Distance(buddy.transform.position, transform.position);
            if (distance < separationDistance) {
                // Move boid away from buddy
                separationVec += (transform.position - buddy.transform.position); 
            }

            // Alignment contribution
            velocityDiff += (buddy.GetComponent<Boid>().velocity - velocity);
        }

        avgGroupPos /= neighbors.Count;
        velocityDiff /= neighbors.Count;

        cohesionVec = (avgGroupPos - transform.position) * cohesionFactor;
        separationVec = separationVec * separationFactor;
        alignmentVec = velocityDiff * alignmentFactor;
  

        // Add contributions
        velocity += cohesionVec + separationVec + alignmentVec;

        Move();
    }

    public void Stop()
    {
        velocity = Vector3.zero;
        Move();
    }

    public void MoveByVector(Vector3 vecToGoal)
    {
        velocity += vecToGoal; 
        Flock();
    }

    private void Move()
    {
        velocity.y = 0.0f; // Don't want to move in y 

        // Limit to max velocity
        if (Vector3.Magnitude(velocity) > maxSpeed)
        {
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }

        float step = speedFactor * Time.deltaTime; 

        // Update position and rotation
        Vector3 newDir = Vector3.RotateTowards(transform.forward, velocity, 3 * step, 0.0f); // Rotation speed: k * speedFactor

        // Test: Draw a ray for the moving direction
        Debug.DrawRay(transform.position, newDir, Color.red);

        transform.position += velocity * step;
        transform.rotation = Quaternion.LookRotation(newDir);
    }

}
