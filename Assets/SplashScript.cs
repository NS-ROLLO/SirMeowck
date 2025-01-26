using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScript : MonoBehaviour
{
    void Start()
    {
        Invoke("Destroy", 0.5f);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
