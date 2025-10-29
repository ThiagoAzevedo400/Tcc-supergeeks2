using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;

    // Start is called before the first frame update
    void Awake()
    {
        if (Singleton != null && Singleton.gameObject != this)
        {
            Destroy(this);
        }
        else
        {
            Singleton = this;
        }
    }


    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
