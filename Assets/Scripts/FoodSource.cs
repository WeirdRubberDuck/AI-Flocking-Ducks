using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSource : MonoBehaviour {

    private float capacity; // The amount of food left in this source (percentage)

    // Use this for initialization
    void Start()
    {
        capacity = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Test if food source is empty
        if (capacity < 0.1f) 
            gameObject.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Boid")) 
            capacity -= 1.0f;  
    }
}
