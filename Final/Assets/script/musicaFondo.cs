using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicaFondo : MonoBehaviour
{
    public musicaFondo instance;
    public musicaFondo Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        } else {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}
