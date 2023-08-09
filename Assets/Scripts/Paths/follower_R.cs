using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class follower_R : MonoBehaviour
{
    public PathCreator pathCreator;
    [HideInInspector]
    public float speed = 5;
    float distanceTravelled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;       
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        //Get the current rotation
        Quaternion currentRotation = transform.rotation;

        //Set the z-rotation to 90 degrees and keep the x and y rotations to zero.
        transform.rotation = Quaternion.Euler(0f, 0f, currentRotation.eulerAngles.x); 

        //Destruction
        if (transform.position.y > 5)
        {   
            TrainSpawner.score++;
            
            Destroy(gameObject); // Destroy the object
        }
        }
}
