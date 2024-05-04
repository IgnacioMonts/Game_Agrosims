using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainManagerDinero : MonoBehaviour
{

    public static mainManagerDinero Instance;
    [SerializeField] public int dinero;
    [SerializeField] public int cultivos;
    [SerializeField] public int decisionesBuenas;
    [SerializeField] public int decisionesMalas;
    [SerializeField] public int decisionesNeutras;
    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    public void AddCultivos(int cantidad) {
        cultivos += cantidad;
    }

}


