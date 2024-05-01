using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class financiamiento : MonoBehaviour
{   
    public void Formal() {
        mainManager.Instance.financiamiento = 1000;
        mainManager.Instance.financiamientoValor = 1;
        print("Financiamiento formal: " + mainManager.Instance.financiamiento);
        mainManager.Instance.interes = 150;
        print("Interes: " + mainManager.Instance.interes);
    }

    public void Informal() {
        mainManager.Instance.financiamiento = 1000;
        mainManager.Instance.financiamientoValor = 2;
        print("Financiamiento informal: " + mainManager.Instance.financiamiento);
        mainManager.Instance.interes = 400;
        print("Interes: " + mainManager.Instance.interes);
    }

    public void Verqor() {
        mainManager.Instance.financiamiento = 1500;
        mainManager.Instance.financiamientoValor = 3;
        print("Financiamiento Verqor: " + mainManager.Instance.financiamiento);
        mainManager.Instance.interes = 375;
        print("Interes: " + mainManager.Instance.interes);
    }
}
