using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UI;

public class contadorMonedas : MonoBehaviour
{
    private int puntos;
    private TextMeshProUGUI textoContador;

    private void Start() {
        textoContador = GetComponent<TextMeshProUGUI>();
        puntos += mainManager.Instance.financiamiento; //sirve para que en requerimientos se muestre el financiamiento elegido
    }

    public void Update() {
        textoContador.text = puntos.ToString();
    }

    public void SumarPuntos(int puntosEntrada) {
        puntos += puntosEntrada;
    }

    public void RestarPuntos(int puntosEntrada) {
        puntos -= puntosEntrada;
    }
}
