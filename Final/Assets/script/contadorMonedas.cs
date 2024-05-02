using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class contadorMonedas : MonoBehaviour
{
    public int puntos;
    private TextMeshProUGUI textoContador;

    public void Start() {
        textoContador = GetComponent<TextMeshProUGUI>();
        // se agrega el dinero del financiamiento al contador de monedas
        puntos += mainManager.Instance.financiamiento;
    }

    public void Update() {
        textoContador.text = puntos.ToString();
        mainManagerDinero.Instance.dinero = puntos;
    }

    public void SumarPuntos(int puntosEntrada) {
        puntos += puntosEntrada;
        Debug.Log("Added points. Total is now: " + puntos);
    }

    public void RestarPuntos(int puntosEntrada) {
        puntos -= puntosEntrada;
        Debug.Log("Subtracted points. Total is now: " + puntos);

    }
}
