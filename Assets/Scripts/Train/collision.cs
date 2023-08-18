using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class collision : MonoBehaviour
{
    
    
    private string[] trains_tag = {"Train_L","Train_R","Train_RR"};
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves the tag "Obstacle" (you can change it to any tag you want)
        if (collision.gameObject.CompareTag(trains_tag[0]) || collision.gameObject.CompareTag(trains_tag[1]) || collision.gameObject.CompareTag(trains_tag[2]))
        {   
            if(Array.Exists(trains_tag, element => element == gameObject.tag))
            {
                TrainSpawner.collisions = TrainSpawner.collisions-0.5f;
            }
            else
            {
                TrainSpawner.collisions = TrainSpawner.collisions-1f;
            }
            
        }
        Destroy(gameObject); // Destroy the object
    }
   
}
