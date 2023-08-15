using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnTouch : MonoBehaviour
{
    

    private void Start()
    {
        // Store the initial position of the object
        
    }

    private void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            float distanceThreshold = 0.3f; // Adjust this value based on your needs

            if (Vector3.Distance(touchPosition, gameObject.transform.position) < distanceThreshold)
            {
                Debug.Log("Touched!");
                Destroy(gameObject); // Destroy the object
            }
            
        }
    }
}