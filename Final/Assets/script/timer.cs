using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Timer : MonoBehaviour{

    [SerializeField] private TMP_Text timertext;
    [SerializeField, Tooltip("Tiempo en segundos") ] private float timerTime;

    [SerializeField] private eventos scriptEventos;

    [SerializeField] private DecisionesAdm scriptDecisiones;

    private bool panelMostrado = false;

    private List<int> decisionesMostradas = new List<int>();

    //private bool decisionMostrada = false;

    private float ultimaDecision = 0f;
    private float intervalo = 60f;
    private int minutes, seconds, miliseconds;

    private void Start()
    {
        //Buscar los scripts eventos y decisiones
        if (scriptEventos == null){
            scriptEventos = FindObjectOfType<eventos>();
        }
        if (scriptDecisiones == null){
            scriptDecisiones = FindObjectOfType<DecisionesAdm>();
        }
    }

    private void Update()
    {

        timerTime -= Time.deltaTime;
        ultimaDecision += Time.deltaTime;


        if(timerTime <= 0f){
            //cargar escena de estadisticas
            SceneManager.LoadScene("Estadisticas");
        }
        else if(timerTime <= 300f && !scriptEventos.PanelActivo && !panelMostrado){
            scriptEventos.PanelRandom();
            panelMostrado = true;
            ultimaDecision = 0f;
        }
        else if(ultimaDecision >= intervalo && decisionesMostradas.Count < scriptDecisiones.NumTDecisiones){
            int decision = scriptDecisiones.DecisionRandom(decisionesMostradas);
            ultimaDecision = 0f;
        }
        
        minutes = (int)(timerTime / 60f);
        seconds = (int)(timerTime - minutes * 60f);
        miliseconds = (int)((timerTime - minutes * 60f - seconds) * 100f);

        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
    /*
    else if(timerTime <= 530f && !scriptDecisiones.DecisionActiva && !decisionMostrada){
            scriptDecisiones.DecisionRandom();
            decisionMostrada = true;
        }
    */
}