using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    
    private string train_tag = "Train";
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves the tag "Obstacle" (you can change it to any tag you want)
        if (collision.gameObject.CompareTag(train_tag))
        {
            Debug.Log("Collision Detected with dthdtdth");
        }
    }
   
}
