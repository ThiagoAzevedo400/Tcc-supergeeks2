using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public UnityEvent InteractEvent;
  public void Interact()
    {
        Debug.Log("Do interaction");
        InteractEvent?.Invoke();
    }

    
}
