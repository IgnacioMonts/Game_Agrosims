using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class financiamiento : MonoBehaviour
{
    //private bool pulsado = false;
    
    public void Formal() {
        mainManager.Instance.financiamiento = 1000;
        print("Financiamiento formal: " + mainManager.Instance.financiamiento);
    }

    public void Informal() {
        mainManager.Instance.financiamiento = 500;
        print("Financiamiento informal: " + mainManager.Instance.financiamiento);
    }

    public void Verqor() {
        mainManager.Instance.financiamiento = 1500;
        print("Financiamiento Verqor: " + mainManager.Instance.financiamiento);
    }
}
