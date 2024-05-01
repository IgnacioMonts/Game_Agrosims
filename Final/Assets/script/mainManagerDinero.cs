using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainManagerDinero : MonoBehaviour
{
    public static mainManagerDinero Instance;
    public int dinero;
    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }
}
