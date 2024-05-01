using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ajustes : MonoBehaviour
{
    private bool pulsado = false;
    private bool salir = false;
    private bool estaPausado = false;
    public GameObject pantallaAjustes;
    public GameObject HUD;
    public Image tache, palomita;
    [SerializeField] private AudioSource audioSource;

    public void Ajustes(){
        // Toggle pause state
        estaPausado = !estaPausado;
        Time.timeScale = estaPausado ? 0 : 1;

        // Toggle UI elements
        pantallaAjustes.SetActive(estaPausado);
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
        pantallaAjustes.SetActive(estaPausado);
        HUD.SetActive(!estaPausado);

        // If exit button was clicked, set salir to true
        salir = !estaPausado;
        Time.timeScale = 1;
    }

/*
    public void Ajustes(){
        //Activa y desactiva la pantalla de creadores al pulsar el boton
        if(pulsado){
            pantallaAjustes.SetActive(false);
            HUD.SetActive(true);
            pulsado = false;
        }else{
            print("prendiendo ajustes");
            estaPausado = !estaPausado;
            Time.timeScale = estaPausado ? 0 : 1;
            pantallaAjustes.SetActive(true);
            HUD.SetActive(false);
            pulsado = true;

        }
    }

    
    public void Cerrar(){
        if(salir){
            pantallaAjustes.SetActive(true);
            HUD.SetActive(false);
            salir = false;
        }else{
            pantallaAjustes.SetActive(false);
            HUD.SetActive(true);
            salir = true;
            Time.timeScale = 1;
            estaPausado = false;
        }
    }
    */

    public void DetenerMusica()
    {
        if (pantallaAjustes.activeSelf)
        {
            if (audioSource.volume > 0.0f)
            {
                audioSource.volume = 0.0f; // Silencio
                tache.gameObject.SetActive(true);
            }
            else
            {
                audioSource.volume = 1.0f; // Volumen máximo
                tache.gameObject.SetActive(false);
            }
        }
    }

    //Funcion que cuando haces click a un boton te pone la pantalla en grande del juego
    public void PantallaCompleta()
    {
        if (pantallaAjustes.activeSelf)
        {
            Screen.fullScreen = !Screen.fullScreen;
            palomita.gameObject.SetActive(!palomita.gameObject.activeSelf);
        }
        
    }

    //Función que envia al usuario a la pantalla de inicio
    public void Salir()
    {
        if (pantallaAjustes.activeSelf)
        {
            SceneManager.LoadScene("Menu");
        }
    }

}
