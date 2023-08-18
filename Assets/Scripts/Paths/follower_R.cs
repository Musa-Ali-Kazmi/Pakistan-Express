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
    bool isFlipped = false;
    
    // Start is called before the first frame update
    void Start()
    {
        string tag = gameObject.tag;
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

        if(tag == "Train_R" || tag == "TNT_R")
        {
        if (transform.position.y  > -1.27 && !isFlipped){
            isFlipped = true;
            FlipX();
        }
        }
        if(tag == "Train_RR" || tag == "TNT_RR")
        {
        if (transform.position.y  > 1.5 && !isFlipped){
            isFlipped = true;
            FlipX();
        }
        }

        //Destruction
        if (transform.position.y > 5)
        {   
            if(tag == "Train_R" || tag == "Train_RR"){
            TrainSpawner.score++;
            Destroy(gameObject); // Destroy the object
            }
            else if(tag == "TNT_R" || tag == "TNT_RR"){
            TrainSpawner.collisions--;
            Destroy(gameObject); // Destroy the object
            }
        }
    }

    private void FlipX()
    {
        Vector3 scale = transform.localScale;
        scale.y *= -1; // Flipping the X scale
        transform.localScale = scale;
    }
}
