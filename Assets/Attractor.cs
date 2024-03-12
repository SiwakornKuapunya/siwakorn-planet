using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private const float G = 6.674f;
    public static List<Attractor> Attractors;

    private void FixedUpdate()
    {
        foreach (var a in Attractors)
        {
            if (a != this)
            {
                Attract(a);
            }
        }
    }

    private void OnEnable()
    {
        if (Attractors == null)
        {
            Attractors = new List<Attractor>();
        }
        Attractors.Add(this);
    }

    void Attract(Attractor other)
    {
        Rigidbody rb2 = other.rb;
        
        Vector3 direction = rb.position - rb2.position;

        float distance = direction.magnitude;

        float forceMagnitude = G * (rb.mass * rb2.mass) / Mathf.Pow(distance, 2);

        Vector3 finalForce = forceMagnitude * direction.normalized;
        
        rb2.AddForce(finalForce);
    }
}
 
