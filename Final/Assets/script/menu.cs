using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasMenu : MonoBehaviour
{

    private bool pulsado = false;

    public GameObject canvaCreadores;
    public GameObject canvaMenu;

    public void CargarEscenaMapa()
    {
        SceneManager.LoadScene("Requerimientos");
    }

    public void Creadores(){
        //Activa y desactiva la pantalla de creadores al pulsar el boton
        if(!pulsado){
            canvaCreadores.SetActive(true);
            canvaMenu.SetActive(false);
            pulsado = false;
        } else {
            canvaCreadores.SetActive(false);
            canvaMenu.SetActive(true);
            pulsado = true;
        }
    }

    public void VolverMenu(){
        //Activa y desactiva la pantalla de creadores al pulsar el boton
        if(!pulsado){
            canvaCreadores.SetActive(false);
            canvaMenu.SetActive(true);
            pulsado = false;
        } else {
            canvaCreadores.SetActive(true);
            canvaMenu.SetActive(false);
            pulsado = true;
        }
    }
}
