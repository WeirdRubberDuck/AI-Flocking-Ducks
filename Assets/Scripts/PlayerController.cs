using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 10.0f; 
	private Rigidbody rb;

    public GameObject foodPrefab;       


    // Called on the first frame
    void Start() 
	{
		rb = GetComponent<Rigidbody> ();
	}

    // Called before performing any physics calculations
    void FixedUpdate()
    {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
    }

    private void Update()
    {
        // Create food when pressing space
        if (Input.GetKeyDown("space"))
        {
            GameObject boid = Instantiate(foodPrefab, transform.position, transform.rotation) as GameObject;
        }
    }
}
