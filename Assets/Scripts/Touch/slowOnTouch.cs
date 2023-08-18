using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowOnTouch : MonoBehaviour
{
    public float newSpeed = 0.2f;
    private float originalSpeed;
    private float timer = 0f;
    private bool isChangingSpeed = false;
    public float maxTouchDistance = 10f;

    // float lastTapTime = -1f;
    // float doubleTapThreshhold = 0.3f;

    private void Start()
    {
        if(tag == "Train_R" || tag == "Train_RR")
        {
        originalSpeed = GetComponent<follower_R>().speed;
        }
        else
        {
        originalSpeed = GetComponent<follower_L>().speed;
        }
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

            if (!isChangingSpeed && Vector3.Distance(touchPosition, gameObject.transform.position) < distanceThreshold)
            {
                isChangingSpeed = true;
                if(tag == "Train_R" || tag == "Train_RR")
                {
                    GetComponent<follower_R>().speed = newSpeed;
                }
                else
                {
                    GetComponent<follower_L>().speed = newSpeed;
                }
            }
            
        }
        
        // If changing speed, update timer
        if (isChangingSpeed)
        {
            timer += Time.deltaTime;

            if (timer >= 3f)
            {
                // Return speed to original value after 5 seconds
                if(tag == "Train_L")
                {
                    GetComponent<follower_L>().speed = originalSpeed;
                }
                else
                {
                    GetComponent<follower_R>().speed = originalSpeed;
                }
                isChangingSpeed = false;
                timer = 0f;
            }
        }
    }
}
