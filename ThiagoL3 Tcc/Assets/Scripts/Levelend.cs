using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelend : MonoBehaviour
{
    public Transform Level_start;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.TryGetComponent(out PlayerMovement player))
            {
                player.transform.position = Level_start.position;
            }
        }
    }
}