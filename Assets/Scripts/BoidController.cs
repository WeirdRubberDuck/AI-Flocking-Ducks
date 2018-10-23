using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour {

	public int flockSize = 10;
	public float spawnRadius;
	public GameObject boidPrefab;       // Our boid

    private GameObject[] boids;

	// Use this for initialization
	void Start () {
		
		boids = new GameObject[flockSize];

		// Initialize boid positions
		for (int i = 0; i < flockSize; i++) {
			Vector3 pos = new Vector3 (Random.Range(-1.0f, 1.0f) * spawnRadius, 0.0f, Random.Range(-1.0f, 1.0f) * spawnRadius); 

			GameObject boid = Instantiate (boidPrefab, transform.position, transform.rotation) as GameObject;
			boid.transform.parent = transform;
			boid.transform.localPosition = pos;
			boids[i] = boid;
		}
	}
}
