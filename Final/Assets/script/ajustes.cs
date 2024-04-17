using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ajustes : MonoBehaviour
{
    private bool pulsado = false;

    public GameObject pantallaAjustes;
    public GameObject HUD;

    public void Ajustes(){
        //Activa y desactiva la pantalla de creadores al pulsar el boton
        if(pulsado){
            pantallaAjustes.SetActive(false);
            HUD.SetActive(true);
            pulsado = false;
        }else{
            pantallaAjustes.SetActive(true);
            HUD.SetActive(false);
            pulsado = true;
        }
    }
}
