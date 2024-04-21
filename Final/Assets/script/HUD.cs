using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public static HUD instance;
    public TMP_Text contadorMonedas;

    public void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    internal void ActualizarMonedas()
    {
        //Obtener el texto del objeto de tipo Text
        int monedas = financiamiento.instance.monedas;
        int monedas2 = botonCosecha.instance.monedas;
        //asignar el valor de monedas
        contadorMonedas.text = monedas.ToString();
        contadorMonedas.text = monedas2.ToString();
    }
}
