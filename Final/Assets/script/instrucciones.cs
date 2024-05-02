using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instrucciones : MonoBehaviour
{
    private bool pulsado = false;
    private bool salir = false;
    private bool estaPausado = false;
    public GameObject pantallaInstrucciones;
    public GameObject HUD;

    public void Instrucciones() {
        // Toggle pause state
        estaPausado = !estaPausado;
        Time.timeScale = estaPausado ? 0 : 1;

        // Toggle UI elements
        pantallaInstrucciones.SetActive(estaPausado);
        HUD.SetActive(!estaPausado);

        // If settings button was clicked, set pulsado to true
        pulsado = estaPausado;
    }

    public void Cerrar(){
        // If game is paused, unpause it
        if (estaPausado) {
            estaPausado = false;
        }

        // Toggle UI elements
        pantallaInstrucciones.SetActive(estaPausado);
        HUD.SetActive(!estaPausado);

        // If exit button was clicked, set salir to true
        salir = !estaPausado;
        Time.timeScale = 1;
    }
}
