using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorJuego : MonoBehaviour
{
    [SerializeField] private float tiempoMaximo;
    private float tiempoActual;
    private bool tiempoActivado = false;

    private void Start() {
        ActivarTemporizador();
    }
    private void Update() {
        if(tiempoActivado) {
            CambiarContador();
        }
    }

    private void CambiarContador() {
        tiempoActual -= Time.deltaTime;
        if(tiempoActual <= 0) {
            tiempoActivado = false;
            Debug.Log("Se acabo el tiempo");
            CambiarTemporizador(false);
        }
    }

    private void CambiarTemporizador(bool estado) {
        tiempoActivado = estado;
    }

    public void ActivarTemporizador() {
        tiempoActual = tiempoMaximo;
        CambiarTemporizador(true);
    }

    public void DesactivarTemporizador() {
        CambiarTemporizador(false);
    }
}
