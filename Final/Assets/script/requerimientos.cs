using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class requerimientos : MonoBehaviour
{
    public void CargarEscena() {
        SceneManager.LoadScene("SampleScene");
    }

    public void Salir() {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

}
