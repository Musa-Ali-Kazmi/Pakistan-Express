using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    private Animator anim;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
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
                animateExplosion();
                StartCoroutine(Destroy());
            }
            
        }
    }


    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject); // Destroy the object
    }
    void animateExplosion()
    {
        Debug.Log("explosion animation");
        anim.SetBool("explode", true);
    }
}