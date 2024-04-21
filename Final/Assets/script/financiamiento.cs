using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class financiamiento : MonoBehaviour
{
    private bool pulsado = false;
    public GameObject Verqor;

    public int monedas = 0;

    //una referencia a una instancia unica
    public static financiamiento instance;

    public void Moneda() {
        //Activa y desactiva la pantalla de creadores al pulsar el boton
        if(pulsado){
            if(Verqor.activeSelf){
                monedas = monedas + 100;
                HUD.instance.ActualizarMonedas();
            }    
        } 
    }
}
