using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class informacion : MonoBehaviour
{
    
    private bool pulsado = false;

    public GameObject PersonajeInfo;
    public GameObject HUD;
    
    public void Info() {
        //Activa y desactiva la pantalla de creadores al pulsar el boton
        if(pulsado) {
            PersonajeInfo.SetActive(false);
            HUD.SetActive(true);
            pulsado = false;
        }else {
            print("mostrando informacion");
            PersonajeInfo.SetActive(true);
            HUD.SetActive(false);
            pulsado = true;
        }
    }
}
