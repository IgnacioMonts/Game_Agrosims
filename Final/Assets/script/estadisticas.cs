using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class estadisticas : MonoBehaviour
{
    public TextMeshProUGUI dinero;
    public TextMeshProUGUI dineroIntereses;
    public TextMeshProUGUI cultivos;
    public TextMeshProUGUI decisionesBuenas;
    public TextMeshProUGUI decisionesMalas;
    public TextMeshProUGUI decisionesNeutras;
    int intereses;
    int total;

    // Start is called before the first frame update
    void Start()
    {
        interes();
    }

    // Update is called once per frame
    void Update()
    {
        dinero.text = mainManagerDinero.Instance.dinero.ToString();
        dineroIntereses.text = total.ToString();
        cultivos.text = mainManagerDinero.Instance.cultivos.ToString();
        decisionesBuenas.text = mainManagerDinero.Instance.decisionesBuenas.ToString();
        decisionesMalas.text = mainManagerDinero.Instance.decisionesMalas.ToString();
        decisionesNeutras.text = mainManagerDinero.Instance.decisionesNeutras.ToString();
    }

    private void interes() {
        intereses = mainManager.Instance.interes;
        Debug.Log("Intereses: " + intereses);
        mainManagerDinero.Instance.dineroIntereses = mainManagerDinero.Instance.dinero - intereses;
        total = mainManagerDinero.Instance.dineroIntereses;
    }
}
