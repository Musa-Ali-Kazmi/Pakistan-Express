using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowing : MonoBehaviour
{
   public Transform target; // The target object you want to follow

    private void Update()
    {
        // Check if the target is assigned
        if (target != null)
        {
            // Set the position of the shadow to match the position of the target
            transform.position = target.position;
        }
        else
        {
            Debug.LogWarning("No target assigned for ShadowFollower.");
        }
    }
}
