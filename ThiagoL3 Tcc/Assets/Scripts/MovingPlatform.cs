using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 point1, point2;

    bool shouldMove = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shouldMove)
        {
            transform.position = Vector3.Lerp(transform.position, point2, 3f * Time.deltaTime);
        }
    }

    public void Move()
    {
        shouldMove = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.TryGetComponent(out PlayerMovement player))
            {
                player.transform.parent = this.transform;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.TryGetComponent(out PlayerMovement player))
            {
                player.transform.parent = null;
            }
        }
    }   
}
