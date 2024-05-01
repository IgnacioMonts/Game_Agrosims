using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventos : MonoBehaviour
{
    [SerializeField] private GameObject[] paneles; //Lista de paneles a mostrar

    [SerializeField] private contadorMonedas puntaje; //puntaje hasta el momento
    private GameObject panelActivo;
    public GameObject botonCultiva;
    public bool PanelActivo {get; private set;}
    private bool estaPausado = false;
    private int puntajeSeguro;
    private int puntajeNuevo;

    public void PanelRandom()
    {
        // Escoger un panel aleatorio
        int randomPanel = Random.Range(0, paneles.Length);
        panelActivo = paneles[randomPanel];

        // Activa el panel
        panelActivo.SetActive(true);
        PanelActivo = true;

        //Cambiar el estado de la pausa
        estaPausado = !estaPausado;

        // Pausa el juego
        Time.timeScale = estaPausado ? 0 : 1;

        // Si el panel que se muestra es el de la nevada
        if (randomPanel == 0)
        {
            // Si el jugador tiene seguro, pierde el 20% de su dinero
            if (mainManager.Instance.seguro)
            {
                puntajeSeguro = (int)(puntaje.puntos * 0.25f);
                puntaje.RestarPuntos(puntajeSeguro);
                puntaje.Update();
            }
            //Si el jugador no tiene seguro, pierde el 50% de su dinero
            else
            {
                puntajeSeguro = (int)(puntaje.puntos * 0.6f);
                puntaje.RestarPuntos(puntajeSeguro);
                puntaje.Update();
            }
        }
        else if(randomPanel == 1){
            //Los botones de cultivar se desactivan por 2 minutos y se activan de nuevo después de este tiempo
            StartCoroutine(DesactivarBotonesCult());
            
            //Se resta el 5% del puntaje actual
            puntajeNuevo = (int)(puntaje.puntos * 0.05f);
            puntaje.RestarPuntos(puntajeNuevo);
            puntaje.Update();
        }
    }

    private IEnumerator DesactivarBotonesCult()
    {
        botonCultiva.SetActive(false);
        yield return new WaitForSeconds(120);
        panelActivo.SetActive(false);
        PanelActivo = false;
    }

    public void Continuar()
    {
        // Desactivar el panel
        if (panelActivo != null)
        {
            panelActivo.SetActive(false);
        }
        PanelActivo = false;

        // Reanudar el juego
        Time.timeScale = 1;
        estaPausado = false;
    }

}
