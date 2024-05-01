using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class estadisticas : MonoBehaviour
{
    public TextMeshProUGUI dinero;
    public TextMeshProUGUI dineroIntereses;
    private contadorMonedas puntaje;
    int intereses;
    int total;

    // Start is called before the first frame update
    void Start()
    {
        intereses = (int) mainManager.Instance.interes * mainManager.Instance.financiamiento;
        total = puntaje.puntos - intereses;
    }

    // Update is called once per frame
    void Update()
    {
        dinero.text = puntaje.puntos.ToString();
        dineroIntereses.text = total.ToString();
    }
}
