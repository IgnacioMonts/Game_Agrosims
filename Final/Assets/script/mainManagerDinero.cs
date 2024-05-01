using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainManagerDinero : MonoBehaviour
{
    public static mainManagerDinero Instance;
    [SerializeField] public int dinero;
    [SerializeField] public int cultivos;
    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

}
