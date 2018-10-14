using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour {

	public float minVelocity = 5;
	public float maxVelocity = 20;
	public int flockSize = 10;
	public float spawnRadius = 2;
	public GameObject boidPrefab;		// Our boid

	public Vector3 flockCenter;
	public Vector3 flockVelocity;

	private GameObject[] boids;

	// Use this for initialization
	void Start () {
		
		boids = new GameObject[flockSize];

		// Initialize boid positions
		for (int i = 0; i < flockSize; i++) {
			Vector3 pos = new Vector3 (Random.Range(-1.0f, 1.0f) * spawnRadius, 0.5f, Random.Range(-1.0f, 1.0f) * spawnRadius); 

			GameObject boid = Instantiate (boidPrefab, transform.position, transform.rotation) as GameObject;
			boid.transform.parent = transform;
			boid.transform.localPosition = pos;
			boids[i] = boid;
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject boid in boids) {
            boid.GetComponent<Boid>().Flock();	
		}
	}
}
