using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{

    public Transform interactionPoint;
    public Transform playerObj;
    public float interactionDistance;

    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DetectInteractableObject();
        }

    }

    void DetectInteractableObject()
    {
        //if (Physics.Raycast(interactionPoint.position, playerObj.forward, out hit, interactionDistance))
        //{
        //    if (hit.collider.TryGetComponent(out interactableObject interactable))
        //    {
        //        interactable.interact();
        //    }
        //}

        Collider[] colls = Physics.OverlapSphere(interactionPoint.position, interactionDistance);
        if (colls.Length > 0)
        {
            foreach (Collider collider in colls)
            {
                print(collider.name);

                if (collider.TryGetComponent(out InteractableObject interactable))
                {
                    interactable.Interact();
                    return;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(interactionPoint.position, interactionDistance);
    }

}
