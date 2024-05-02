using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UI;

public class contadorCultivos : MonoBehaviour
{
    public int puntos;
    private TextMeshProUGUI textoContador;

    private void Start() {
        textoContador = GetComponent<TextMeshProUGUI>();
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
