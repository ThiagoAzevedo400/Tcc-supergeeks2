using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    public string currentScene;
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.TryGetComponent(out PlayerMovement player))
            {
                GameManager.Singleton.ChangeScene(currentScene);
            }
        }
    }
}
