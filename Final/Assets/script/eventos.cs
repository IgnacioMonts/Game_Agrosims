using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class eventos : MonoBehaviour
{
    [SerializeField] private GameObject[] paneles; //Lista de paneles a mostrar

    [SerializeField] private contadorMonedas puntaje; //puntaje hasta el momento

    [SerializeField] private controladorJuego[] timerCultivo; //Controlador del tiempo de cultivo

    [SerializeField] private GameObject[] botonesCultivo; //Botones de cultivo

    [SerializeField] private GameObject[] cultivos; //Cultivos

    //[SerializeField] private GameObject[] botonesCosecha; //Botones de cosecha

    private GameObject panelActivo;
    //public GameObject botonCultiva;
    //public GameObject cultivo;
    //public GameObject botonCosecha;
    public bool PanelActivo {get; private set;}
    private bool estaPausado = false;
    private int puntajeSeguro;
    private int puntajeNuevo;
    private bool habilitarCultivar = false;


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
            if (mainManager.Instance.seguro == true)
            {
                puntajeSeguro = (int)(puntaje.puntos * 0.25f);
                puntaje.RestarPuntos(puntajeSeguro);
            }
            //Si el jugador no tiene seguro, pierde el 50% de su dinero
            else
            {
                puntajeSeguro = (int)(puntaje.puntos * 0.6f);
                puntaje.RestarPuntos(puntajeSeguro);
            }
        }
        else if(randomPanel == 1){
            //Los botones de cultivar se desactivan por 2 minutos y se activan de nuevo después de este tiempo
            StartCoroutine(DesactivarBotonesCult());
            
            //Se resta el 5% del puntaje actual
            puntajeNuevo = (int)(puntaje.puntos * 0.05f);
            puntaje.RestarPuntos(puntajeNuevo);
        }
        else if(randomPanel == 2){
            StartCoroutine(Tormenta());
        }
    }

    //Función para activar o desactivar elementos de la escena
    private void ActivarElementos(IEnumerable<GameObject> elems, bool value)
    {
        foreach (var elem in elems)
        {
            elem.SetActive(value);
        }
    }

    //Activa o desactiva los timers de los cultivos
    private void ActivarTimers(bool value)
    {
        foreach (var timer in timerCultivo)
        {
            if (value)
            {
                timer.ActivarTemporizador();
            }
            else
            {
                timer.DesactivarTemporizador();
            }
        }
    }

    //Corrutina para las consecuencias de la tormenta
    private IEnumerator Tormenta()
    {
        ActivarElementos(cultivos, false);
        ActivarElementos(botonesCultivo, false);
        ActivarTimers(false);

        yield return new WaitForSeconds(60);

        ActivarElementos(botonesCultivo, true);
    }

    public bool HabilitarCultivar
    {
        get { return habilitarCultivar; }
    }

    //Corrutina para desactivar los botones de cultivo por 2 minutos
    private IEnumerator DesactivarBotonesCult()
    {
        habilitarCultivar = false;
        ActivarElementos(botonesCultivo, false);
        
        yield return new WaitForSeconds(120);

        habilitarCultivar = true;
    }

    //Función para regresar al juego
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
