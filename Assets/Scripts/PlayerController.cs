using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed; 
	private Rigidbody rb;

	// Called on the first frame
	void Start() 
	{
		rb = GetComponent<Rigidbody> ();
	}

    // Called before rendering a frame
//    void Update()
//    {
//        
//    }

    // Called before performing any physics calculations
    void FixedUpdate()
    {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
    }
}
