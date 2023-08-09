using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BezierPath : MonoBehaviour
{
    public Transform[] controlPoints; // Assign the control points in the Inspector
    public float speed = 2f;

    private float t;

    private void Update()
    {
        t += speed * Time.deltaTime;
        if (t > 1f)
        {
            t = 1f;
        }

        Vector3 newPosition = CalculateBezierPoint(t, controlPoints[0].position, controlPoints[1].position, controlPoints[2].position, controlPoints[3].position);
        transform.position = newPosition;

        Vector3 direction = CalculateBezierTangent(t, controlPoints[0].position, controlPoints[1].position, controlPoints[2].position, controlPoints[3].position);
        transform.rotation = Quaternion.LookRotation(direction);

        Vector3 eulerRotation = Quaternion.LookRotation(direction).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, 0f, eulerRotation.x);
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves the tag "Obstacle" (you can change it to any tag you want)
        if (collision.gameObject.CompareTag("Train"))
        {
            Debug.Log("Collision Detected with dthdtdth");
        }
    }
    private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1f - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3f * uu * t * p1;
        p += 3f * u * tt * p2;
        p += ttt * p3;

        return p;
    }

    private Vector3 CalculateBezierTangent(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1f - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 tangent = -3f * uu * p0;
        tangent += (3f * uu - 6f * t) * p1;
        tangent += (-3f * tt + 6f * t) * p2;
        tangent += 3f * tt * p3;

        return tangent.normalized;
    }
}
