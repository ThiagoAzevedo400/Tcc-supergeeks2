using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Rigidbody rb;

    bool shouldMove = false;

    float collisionDegree;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shouldMove)
        {
            if (!(collisionDegree >= 80 && collisionDegree <= 100))
            { 
            
                // estou colidindo em qualquer lado
                rb.isKinematic = true;
            }
            else
            {
                // estou colidindo no lado para empurrar
                rb.isKinematic = false;
                rb.constraints = RigidbodyConstraints.FreezePositionY;
                rb.freezeRotation = true;
            }

        }
        else
        {
            rb.isKinematic = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision != null)
        {
            if (collision.collider.TryGetComponent(out PlayerMovement p))
            {
                shouldMove = false;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.collider.TryGetComponent(out PlayerMovement p))
            {
                Vector3 normal = collision.contacts[0].normal;

                collisionDegree = Vector3.Angle(normal, Vector3.down);

                shouldMove = true;
            }
        }
    }
}
