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
    [SerializeField]
    private GameObject clock;
    public GameObject spawnedClock;
    //OPACITY
    private float targetOpacity = 0.8f; // The desired opacity value (between 0 and 1)

    private Renderer objectRenderer; // Reference to the object's renderer component
    //OPACITY

    private void Start()
    {   
        //OPACITY
        objectRenderer = GetComponent<Renderer>();
        //OPACITY
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
            float distanceThreshold = 0.5f; // Adjust this value based on your needs

            if (!isChangingSpeed && Vector3.Distance(touchPosition, gameObject.transform.position) < distanceThreshold)
            {
                isChangingSpeed = true;
                if(tag == "Train_R" || tag == "Train_RR")
                {
                    GetComponent<follower_R>().speed = newSpeed;
                    spawnedClock = Instantiate(clock);
                    //OPACITY
                    ChangeObjectOpacity(targetOpacity);
                }
                else
                {
                    GetComponent<follower_L>().speed = newSpeed;
                    spawnedClock = Instantiate(clock);
                    //OPACITY
                    ChangeObjectOpacity(targetOpacity);
                }
            }
            
        }
        
        // If changing speed, update timer
        if (isChangingSpeed)
        {   
            spawnedClock.transform.position = gameObject.transform.position;
            timer += Time.deltaTime;

            if (timer >= 3f)
            {
                // Return speed to original value after 5 seconds
                if(tag == "Train_L")
                {
                    GetComponent<follower_L>().speed = originalSpeed;
                    Destroy(spawnedClock);
                    ChangeObjectOpacity(1f);
                }
                else
                {
                    GetComponent<follower_R>().speed = originalSpeed;
                    Destroy(spawnedClock);
                    ChangeObjectOpacity(1f);
                }
                isChangingSpeed = false;
                timer = 0f;
            }
        }
    }

    private void ChangeObjectOpacity(float opacity)
    {
        // Get the current material color
        Color currentColor = objectRenderer.material.color;

        // Set the new alpha value while keeping the existing RGB values
        Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, opacity);

        // Apply the new color to the material
        objectRenderer.material.color = newColor;
    }
}
