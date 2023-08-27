using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class collision : MonoBehaviour
{
    private Animator anim;
    private bool collided = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    private string[] trains_tag = {"Train_L","Train_R","Train_RR"};
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collided)
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
        collided = true;
        animateExplosion();
        StartCoroutine(Destroy());
        }
    }
    
    
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject); // Destroy the object
        if(gameObject.tag == "Train_L" || gameObject.tag == "Train_R" || gameObject.tag == "Train_RR")
        {
            Destroy(gameObject.GetComponent<slowOnTouch>().spawnedClock);
        }
    }

    void animateExplosion()
    {
        Debug.Log("explosion animation");
        anim.SetBool("explode", true);
    }
}
