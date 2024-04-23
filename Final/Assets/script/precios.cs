using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class precios : MonoBehaviour
{
    public GameObject maizTradicional;
    public GameObject maizRegenerativa;
    public GameObject trigoTradicional;
    public GameObject trigoRegenerativa;
    public GameObject papaTradicional;
    public GameObject papaRegenerativa;
    public GameObject tomateTradicional;
    public GameObject tomateRegenerativa;

    void Start() {
        if(mainManager.Instance.agricultura == true)
        {
            maizTradicional.SetActive(false);
            maizRegenerativa.SetActive(true);
            trigoTradicional.SetActive(false);
            trigoRegenerativa.SetActive(true);
            papaTradicional.SetActive(false);
            papaRegenerativa.SetActive(true);
            tomateTradicional.SetActive(false);
            tomateRegenerativa.SetActive(true);
        }
        else
        {
            maizTradicional.SetActive(true);
            maizRegenerativa.SetActive(false);
            trigoTradicional.SetActive(true);
            trigoRegenerativa.SetActive(false);
            papaTradicional.SetActive(true);
            papaRegenerativa.SetActive(false);
            tomateTradicional.SetActive(true);
            tomateRegenerativa.SetActive(false);
        }
    }
    
}
